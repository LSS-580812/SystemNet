
namespace SocketClientEX01_Form
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnSendText = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblDataSent = new System.Windows.Forms.Label();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(250, 46);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "btnDisconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(418, 45);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 1;
            this.btnImage.Text = "btnImage";
            this.btnImage.UseVisualStyleBackColor = true;
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(634, 214);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(75, 23);
            this.btnSendText.TabIndex = 2;
            this.btnSendText.Text = "btnSendText";
            this.btnSendText.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(250, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // lblDataSent
            // 
            this.lblDataSent.AutoSize = true;
            this.lblDataSent.Location = new System.Drawing.Point(49, 130);
            this.lblDataSent.Name = "lblDataSent";
            this.lblDataSent.Size = new System.Drawing.Size(58, 12);
            this.lblDataSent.TabIndex = 4;
            this.lblDataSent.Text = "lblDataSent";
            // 
            // txtBox1
            // 
            this.txtBox1.Location = new System.Drawing.Point(51, 214);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(557, 22);
            this.txtBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.lblDataSent);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSendText);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnDisconnect);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblDataSent;
        private System.Windows.Forms.TextBox txtBox1;
    }
}

