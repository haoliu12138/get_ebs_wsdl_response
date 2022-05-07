using System;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace 获取wadl输入报文
{
    //定义结构体
    public struct Node_Nt_Rec_type
    {
        public string Node_Name;
        public string ParentNode_type;
        public string Node_type;
        public string Node_Db_type;
    };

    public struct Inparam_type
    {
        public string Node_Name;
        public string Node_type;
        public string Node_Db_type;
    };
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置下拉列表的默认值为xml
            Format.SelectedIndex = 0;
            //在获取方法之前生成报文按不可点
            if (Methods.Text.Equals(""))
            {
                GenerateReport.Enabled = false;
            }

        }
        /// <summary>
        /// 获取报文按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlDocument xsdDoc;
            List<Node_Nt_Rec_type> allElement = new List<Node_Nt_Rec_type>();
            List<Inparam_type> allTag = new List<Inparam_type>();
            XmlNodeList elements = null;
            XmlNodeList outElement = null;
            string result = "";
            string rootTag="";
            string rootXmlns;
            string restHeaderXmlns="";
            //从指定的url读取xml 
            try
            {
                doc.Load(Url.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            //这种方式是可行的 xpath由于xmlns属性的影响导致获取不到
            //include节点
            XmlNodeList includes = doc.GetElementsByTagName("include");

            //获取include节点的href属性,这里由于可能有多个方法所以需要结合获取到的选中的方法名来获得
            string xsdHref = "";
            for (int i = 0; i < includes.Count; i++)
            {
                string href = includes.Item(i).Attributes["href"].Value;
                if (Methods.Text.Equals(""))
                {
                    MessageBox.Show("请选择你要生成报文的方法");
                    return;
                }
                else
                {
                    //这里使用正则表达式匹配
                    if (Regex.IsMatch(href, @"XSD=" + Methods.Text.ToUpper() + "_SYNCH_TYPEDEF.xsd"))
                    {
                        xsdHref = href;
                    }
                }
            }
            if (!xsdHref.Equals(""))
            {
                //访问xsd文件 
                xsdDoc = new XmlDocument();
                xsdDoc.Load(xsdHref);
                //获取输入的参数的标签
            }
            else
            {
                MessageBox.Show("未获取到xsd文件的路径");
                return;
            }
            //获取根节点的xmlns属性
            rootXmlns = xsdDoc.GetElementsByTagName("schema").Item(0).Attributes["targetNamespace"].Value;
            //获取restHeader的xmlns属性
            XmlNodeList import=xsdDoc.GetElementsByTagName("import");
            foreach(XmlNode node in import)
            {
                if(node.Attributes["namespace"].Value.EndsWith("/header"))
                {
                    restHeaderXmlns=node.Attributes["namespace"].Value;
                }
            }
            //获取所有element标签
            elements = xsdDoc.GetElementsByTagName("element");
            foreach (XmlNode node in elements)
            {
                //过滤没有name属性的 element标签
                if (node.Attributes[0].Name == "name")
                {
                    //有的eelement节点没有name属性要注意
                    if (node.Attributes["name"].Value.Equals(Methods.Text.ToUpper() + "_Input"))
                    {
                        //获取根节点的标签名
                        rootTag = node.Attributes["name"].Value;
                    }
                    else if (node.Attributes["name"].Value.Equals("InputParameters"))
                    {
                        //如果在这里element标签的name属性是 InputParameters
                        //获取说有最外层参数名
                        //获取element->complexType->sequence->element
                        outElement = node.FirstChild.FirstChild.ChildNodes;
                    }
                }
            }
            //这里循环递归生成了xml格式输出报文
            for (int i = 0; i < outElement.Count; i++)
            {
                XmlNode node = outElement.Item(i);
                Inparam_type rec;
                rec.Node_Name = "<" + node.Attributes["name"].Value + ">";
                rec.Node_type = node.Attributes["type"].Value;
                rec.Node_Db_type = "";
                allTag.Add(rec);
                Cux_Get_Elem_Name(xsdDoc, node.Attributes["type"].Value, allTag);
                rec.Node_Name = "</" + node.Attributes["name"].Value + ">";
                allTag.Add(rec);
            }

            //获得xml格式的报文
            foreach (Inparam_type a in allTag)
            {
                result = result + a.Node_Name;
            }
            //在xml的根节点加入属性xmlns：json='http://james.newtonking.com/projects/json' 并在需要成为数组的标签加入属性json:Array='true' 
            //result = "<InputParameters xmlns:json='http://james.newtonking.com/projects/json'>" + result + "</InputParameters>";
            if(Format.Text.ToUpper().Equals("XML"))
            {
                string xmlResult=   "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>"+
                                    "<" + rootTag + " xmlns=\"" + rootXmlns + "\">"+
                                    "<RESTHeader xmlns=\""+restHeaderXmlns+"\">"+
                                    "<Responsibility></Responsibility>"+
                                    "<RespApplication></RespApplication>"+
                                    "<SecurityGroup></SecurityGroup>"+
                                    "<NLSLanguage>SIMPLIFIED CHINESE</NLSLanguage>"+
                                    "<Org_Id>0</Org_Id>"+
                                    "</RESTHeader>"+
                                    "<InputParameters>"+
                                    result+
                                    "</InputParameters>"+
                                    "</" + rootTag + ">";
                Result.Text = xmlResult.Replace(" json:Array='true'", "");
                                                           
               
            }
            else if (Format.Text.ToUpper().Equals("JSON"))
            {
                //在xml的根节点加入属性xmlns：json='http://james.newtonking.com/projects/json' 并在需要成为数组的标签加入属性json:Array='true' 
                result = "<InputParameters xmlns:json='http://james.newtonking.com/projects/json'>" + result + "</InputParameters>";
                XmlDocument jsonFromXml = new XmlDocument();
                jsonFromXml.LoadXml(result);
                //将xml转为json
                string json=JsonConvert.SerializeXmlNode(jsonFromXml);
                json = "{" +
                        "\"" + rootTag + "\":{" +
                        "\"@xmlns\":\"" + rootXmlns + "\"," +
                        "\"RESTHeader\":{" +
                        "\"@xmlns\":\"" + restHeaderXmlns + "\"," +
                        "\"Responsibility\": \"\"," +
                        "\"RespApplication\": \"\"," +
                        "\"SecurityGroup\": \"\"," +
                        "\"NLSLanguage\": \"SIMPLIFIED CHINESE\"," +
                        "\"Org_Id\": \"0\"" +
                        "}," +
                        json.Substring(1, json.Length - 2) + "}}";
                        
                        //上面的去掉首尾字符是为了去掉大括号，因为转换过来的json字符串是中间的，但是他外面有大括号不需要
                Result.Text = json;
            }
            MessageBox.Show("生成完成");
        }
        #endregion
        /// <summary>
        /// 获取方法按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void GetMethod_Click(object sender, EventArgs e)
        {
            //清空原来下拉列表里的所有值防止上回的方法还在里面
            Methods.Items.Clear();
            XmlDocument doc = new XmlDocument();
            //从指定的url读取xml 
            try
            {
                doc.Load(Url.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            //application节点
            //在根节点的属性xmlns:tns+序号属性里有方法名
            XmlNodeList applications = doc.GetElementsByTagName("application");
            XmlNode application = applications[0];
            //获取所有方法的名字
            for (int i = 0; i < application.Attributes.Count; i++)
            {
                //这个里放着服务器别名
                if (application.Attributes[i].Name.Equals("xmlns:tns"))
                {
                    string text = application.Attributes[i].Value;
                    text = text.Substring(0, text.Length - 1);
                    text = text.Substring(text.LastIndexOf("/") + 1);
                    //获取到了方法后让生成报文可点击
                    if (Methods.Text.Equals(""))
                    {
                        GenerateReport.Enabled = true;
                    }
                    ServerName.Text = text;
                }
                else if (application.Attributes[i].Name.Contains("xmlns:tns"))
                {
                    string text = application.Attributes[i].Value;
                    text = text.Substring(0, text.Length - 1);
                    text = text.Substring(text.LastIndexOf("/") + 1);
                    Methods.Items.Add(text);
                }

            }
            //默认方法为选中的第一个方法 得先有方法
            Methods.SelectedIndex = 0;
            MessageBox.Show("获取方法完成");
        }
        #endregion
       
        /// <summary>
        /// 递归将节点按照顺序放入集合
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="NodeType"></param>
        /// <param name="list"></param>
        #region
        public void Cux_Get_Elem_Name(XmlDocument doc, string NodeType, List<Inparam_type> list)
        {
            //获取所有complexType标签的节点
            XmlNodeList l_xsd_nodelist = doc.GetElementsByTagName("complexType");
            XmlNodeList elementList = null;
            //不管这样这个complexType都是可以得到的 complexType节点一直都有
            //传入NodeType节点类型为空就是一定没有子节点了停止递归
            if (!string.IsNullOrEmpty(NodeType))
            {
                if (l_xsd_nodelist.Count > 0)
                {
                    foreach (XmlNode node in l_xsd_nodelist)
                    {
                        if (node.Attributes.Count > 0)
                        {
                            //获取complexType 的name属性等于输入的 NodeType的下面的element节点
                            if (node.Attributes["name"].Value == NodeType.Substring(3))
                            {
                                elementList = node.FirstChild.ChildNodes;
                            }
                        }
                    }
                    //递归停止条件 就算有NodeType也有可能没有子节点
                    if (elementList != null)
                    {
                        for (int i = 0; i < elementList.Count; i++)
                        {
                            XmlNode node = elementList.Item(i);
                            Inparam_type rec;
                            //给 Node_Db_type赋值通过这个判断是否是数组属性
                            if (node.Attributes[node.Attributes.Count - 2].Name == "maxOccurs")
                            {
                                rec.Node_Db_type = node.Attributes["maxOccurs"].Value;
                            }
                            else
                            {
                                rec.Node_Db_type = null;
                            }
                            if (rec.Node_Db_type == null)
                            {
                                rec.Node_Name = "<" + node.Attributes["name"].Value + ">";
                            }
                            else
                            {
                                rec.Node_Name = "<" + node.Attributes["name"].Value + " json:Array='true'>";
                            }

                            //有的例如varchar2没有 type属性只有db_type
                            if (node.Attributes[1].Name != "type")
                            {
                                rec.Node_type = null;
                            }
                            else
                            {
                                rec.Node_type = node.Attributes["type"].Value;
                            }
                            list.Add(rec);
                            Cux_Get_Elem_Name(doc, rec.Node_type, list);
                            //加入终止标签 因为xml都是一对一对的
                            rec.Node_Name = "</" + node.Attributes["name"].Value + ">";
                            list.Add(rec);
                        }
                    }
                }
            }
        }
        #endregion

        private void CopyF_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Url.Text))
            {
                System.Windows.Forms.Clipboard.SetText(Url.Text.Substring(0, Url.Text.IndexOf("/webservices/rest/", 0)));
                MessageBox.Show(Url.Text.Substring(0, Url.Text.IndexOf("/webservices/rest/", 0)));
            }
            else
            {
                MessageBox.Show("报文为空");
            }
        }

        private void CopyB_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ServerName.Text) && !string.IsNullOrEmpty(Methods.Text))
            {
                System.Windows.Forms.Clipboard.SetText("/webservices/rest/" + ServerName.Text + "/" + Methods.Text + "/");
                MessageBox.Show("/webservices/rest/" + ServerName.Text + "/" + Methods.Text + "/");
            }
            else
            {
                MessageBox.Show("请先获取方法");
            }
        }

        private void CopyBW_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Result.Text))
            {
                MessageBox.Show("请先生成报文");
            }
        }



    }

}
