
namespace 获取wadl输入报文
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GenerateReport = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Format = new System.Windows.Forms.ComboBox();
            this.Methods = new System.Windows.Forms.ComboBox();
            this.GetMethod = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CopyF = new System.Windows.Forms.Button();
            this.CopyB = new System.Windows.Forms.Button();
            this.CopyBW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Url
            // 
            this.Url.Location = new System.Drawing.Point(111, 76);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(634, 28);
            this.Url.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "WADL：";
            // 
            // GenerateReport
            // 
            this.GenerateReport.Location = new System.Drawing.Point(957, 138);
            this.GenerateReport.Name = "GenerateReport";
            this.GenerateReport.Size = new System.Drawing.Size(120, 36);
            this.GenerateReport.TabIndex = 2;
            this.GenerateReport.Text = "生成报文";
            this.GenerateReport.UseVisualStyleBackColor = true;
            this.GenerateReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(111, 231);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(966, 120);
            this.Result.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "输出报文";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "格式：";
            // 
            // Format
            // 
            this.Format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Format.FormattingEnabled = true;
            this.Format.Items.AddRange(new object[] {
            "XML",
            "JSON"});
            this.Format.Location = new System.Drawing.Point(111, 144);
            this.Format.Name = "Format";
            this.Format.Size = new System.Drawing.Size(136, 26);
            this.Format.TabIndex = 7;
            // 
            // Methods
            // 
            this.Methods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Methods.FormattingEnabled = true;
            this.Methods.Location = new System.Drawing.Point(396, 144);
            this.Methods.Name = "Methods";
            this.Methods.Size = new System.Drawing.Size(280, 26);
            this.Methods.TabIndex = 8;
            // 
            // GetMethod
            // 
            this.GetMethod.Location = new System.Drawing.Point(984, 69);
            this.GetMethod.Name = "GetMethod";
            this.GetMethod.Size = new System.Drawing.Size(94, 39);
            this.GetMethod.TabIndex = 9;
            this.GetMethod.Text = "获取方法";
            this.GetMethod.UseVisualStyleBackColor = true;
            this.GetMethod.Click += new System.EventHandler(this.GetMethod_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(764, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "服务别名";
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(848, 75);
            this.ServerName.Name = "ServerName";
            this.ServerName.ReadOnly = true;
            this.ServerName.Size = new System.Drawing.Size(115, 28);
            this.ServerName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 148);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "入口方法：";
            // 
            // CopyF
            // 
            this.CopyF.Location = new System.Drawing.Point(111, 190);
            this.CopyF.Name = "CopyF";
            this.CopyF.Size = new System.Drawing.Size(206, 35);
            this.CopyF.TabIndex = 13;
            this.CopyF.Text = "复制EndPoint到剪切板";
            this.CopyF.UseVisualStyleBackColor = true;
            this.CopyF.Click += new System.EventHandler(this.CopyF_Click);
            // 
            // CopyB
            // 
            this.CopyB.Location = new System.Drawing.Point(396, 190);
            this.CopyB.Name = "CopyB";
            this.CopyB.Size = new System.Drawing.Size(211, 35);
            this.CopyB.TabIndex = 14;
            this.CopyB.Text = "复制resource到剪切板";
            this.CopyB.UseVisualStyleBackColor = true;
            this.CopyB.Click += new System.EventHandler(this.CopyB_Click);
            // 
            // CopyBW
            // 
            this.CopyBW.Location = new System.Drawing.Point(683, 190);
            this.CopyBW.Name = "CopyBW";
            this.CopyBW.Size = new System.Drawing.Size(142, 35);
            this.CopyBW.TabIndex = 15;
            this.CopyBW.Text = "复制报文";
            this.CopyBW.UseVisualStyleBackColor = true;
            this.CopyBW.Click += new System.EventHandler(this.CopyBW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 369);
            this.Controls.Add(this.CopyBW);
            this.Controls.Add(this.CopyB);
            this.Controls.Add(this.CopyF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GetMethod);
            this.Controls.Add(this.Methods);
            this.Controls.Add(this.Format);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.GenerateReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Url);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "REST接口报文生成工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GenerateReport;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Format;
        private System.Windows.Forms.ComboBox Methods;
        private System.Windows.Forms.Button GetMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CopyF;
        private System.Windows.Forms.Button CopyB;
        private System.Windows.Forms.Button CopyBW;
    }
}

