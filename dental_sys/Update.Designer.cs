
namespace dental_sys
{
    partial class Update
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxVisitorNameU = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtMeetTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdateU = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtMeetDateU = new Guna.UI2.WinForms.Guna2DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(188, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 23);
            this.label1.TabIndex = 40;
            this.label1.Text = "Date";
            // 
            // txtBoxVisitorNameU
            // 
            this.txtBoxVisitorNameU.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxVisitorNameU.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtBoxVisitorNameU.BorderRadius = 5;
            this.txtBoxVisitorNameU.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxVisitorNameU.DefaultText = "";
            this.txtBoxVisitorNameU.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxVisitorNameU.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxVisitorNameU.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxVisitorNameU.DisabledState.Parent = this.txtBoxVisitorNameU;
            this.txtBoxVisitorNameU.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxVisitorNameU.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtBoxVisitorNameU.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxVisitorNameU.FocusedState.Parent = this.txtBoxVisitorNameU;
            this.txtBoxVisitorNameU.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtBoxVisitorNameU.ForeColor = System.Drawing.Color.Black;
            this.txtBoxVisitorNameU.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxVisitorNameU.HoverState.Parent = this.txtBoxVisitorNameU;
            this.txtBoxVisitorNameU.Location = new System.Drawing.Point(192, 152);
            this.txtBoxVisitorNameU.Name = "txtBoxVisitorNameU";
            this.txtBoxVisitorNameU.PasswordChar = '\0';
            this.txtBoxVisitorNameU.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtBoxVisitorNameU.PlaceholderText = "";
            this.txtBoxVisitorNameU.SelectedText = "";
            this.txtBoxVisitorNameU.ShadowDecoration.Parent = this.txtBoxVisitorNameU;
            this.txtBoxVisitorNameU.Size = new System.Drawing.Size(496, 32);
            this.txtBoxVisitorNameU.TabIndex = 43;
            this.txtBoxVisitorNameU.TextChanged += new System.EventHandler(this.txtBoxVisitorNameU_TextChanged);
            this.txtBoxVisitorNameU.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxVisitorNameU_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(188, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 23);
            this.label6.TabIndex = 44;
            this.label6.Text = "Visitor names";
            // 
            // dtMeetTime
            // 
            this.dtMeetTime.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
            this.dtMeetTime.CustomFormat = "HH:MM";
            this.dtMeetTime.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMeetTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMeetTime.Location = new System.Drawing.Point(443, 259);
            this.dtMeetTime.Name = "dtMeetTime";
            this.dtMeetTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtMeetTime.ShowUpDown = true;
            this.dtMeetTime.Size = new System.Drawing.Size(94, 30);
            this.dtMeetTime.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(439, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 46;
            this.label2.Text = "Time";
            // 
            // btnUpdateU
            // 
            this.btnUpdateU.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdateU.BorderRadius = 5;
            this.btnUpdateU.BorderThickness = 1;
            this.btnUpdateU.CheckedState.Parent = this.btnUpdateU;
            this.btnUpdateU.CustomImages.Parent = this.btnUpdateU;
            this.btnUpdateU.DisabledState.Parent = this.btnUpdateU;
            this.btnUpdateU.FillColor = System.Drawing.Color.Transparent;
            this.btnUpdateU.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdateU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdateU.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdateU.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnUpdateU.HoverState.Parent = this.btnUpdateU;
            this.btnUpdateU.Location = new System.Drawing.Point(635, 680);
            this.btnUpdateU.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateU.Name = "btnUpdateU";
            this.btnUpdateU.ShadowDecoration.Parent = this.btnUpdateU;
            this.btnUpdateU.Size = new System.Drawing.Size(210, 37);
            this.btnUpdateU.TabIndex = 48;
            this.btnUpdateU.Text = "Update";
            this.btnUpdateU.Click += new System.EventHandler(this.btnUpdateU_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtMeetDateU
            // 
            this.dtMeetDateU.BackColor = System.Drawing.Color.Transparent;
            this.dtMeetDateU.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dtMeetDateU.BorderRadius = 5;
            this.dtMeetDateU.BorderThickness = 1;
            this.dtMeetDateU.CheckedState.Parent = this.dtMeetDateU;
            this.dtMeetDateU.CustomFormat = "hh:mm";
            this.dtMeetDateU.FillColor = System.Drawing.SystemColors.Control;
            this.dtMeetDateU.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtMeetDateU.ForeColor = System.Drawing.Color.Black;
            this.dtMeetDateU.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMeetDateU.HoverState.Parent = this.dtMeetDateU;
            this.dtMeetDateU.Location = new System.Drawing.Point(192, 259);
            this.dtMeetDateU.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtMeetDateU.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtMeetDateU.Name = "dtMeetDateU";
            this.dtMeetDateU.ShadowDecoration.Parent = this.dtMeetDateU;
            this.dtMeetDateU.Size = new System.Drawing.Size(154, 43);
            this.dtMeetDateU.TabIndex = 49;
            this.dtMeetDateU.Value = new System.DateTime(2021, 10, 26, 0, 0, 0, 0);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1312, 769);
            this.Controls.Add(this.dtMeetDateU);
            this.Controls.Add(this.btnUpdateU);
            this.Controls.Add(this.dtMeetTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxVisitorNameU);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Update";
            this.Text = "Update";
            this.Load += new System.EventHandler(this.Update_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxVisitorNameU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtMeetTime;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnUpdateU;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtMeetDateU;
    }
}