namespace DataGridViewButtonDemo.DataGridViewCellButtonHelper
{
    partial class CellButtonCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCellAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCellAction
            // 
            this.buttonCellAction.Image = global::DataGridViewButtonDemo.Properties.Resources.bullet_blue16;
            this.buttonCellAction.Location = new System.Drawing.Point(0, 0);
            this.buttonCellAction.Name = "buttonCellAction";
            this.buttonCellAction.Size = new System.Drawing.Size(25, 21);
            this.buttonCellAction.TabIndex = 1;
            this.buttonCellAction.UseVisualStyleBackColor = true;
            this.buttonCellAction.Click += new System.EventHandler(this.buttonCellAction_Click);
            // 
            // CellButtonCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCellAction);
            this.Name = "CellButtonCtrl";
            this.Size = new System.Drawing.Size(24, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCellAction;
    }
}
