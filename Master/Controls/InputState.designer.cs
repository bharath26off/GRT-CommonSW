
namespace FBI_D57
{
    partial class InputState
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DGV_Input = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Input)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Input
            // 
            this.DGV_Input.AllowUserToAddRows = false;
            this.DGV_Input.AllowUserToDeleteRows = false;
            this.DGV_Input.AllowUserToResizeColumns = false;
            this.DGV_Input.AllowUserToResizeRows = false;
            this.DGV_Input.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Input.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Input.ColumnHeadersVisible = false;
            this.DGV_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Input.Location = new System.Drawing.Point(0, 0);
            this.DGV_Input.Name = "DGV_Input";
            this.DGV_Input.ReadOnly = true;
            this.DGV_Input.RowHeadersVisible = false;
            this.DGV_Input.RowTemplate.Height = 23;
            this.DGV_Input.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Input.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_Input.Size = new System.Drawing.Size(1128, 408);
            this.DGV_Input.TabIndex = 1;
            this.DGV_Input.SelectionChanged += new System.EventHandler(this.DGV_Input_SelectionChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InputState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV_Input);
            this.Name = "InputState";
            this.Size = new System.Drawing.Size(1128, 408);
            this.Load += new System.EventHandler(this.InputState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Input)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Input;
        private System.Windows.Forms.Timer timer1;
    }
}
