
namespace FBI_D57
{
    partial class OutputState
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
            this.DGV_Output = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Output)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Output
            // 
            this.DGV_Output.AllowUserToAddRows = false;
            this.DGV_Output.AllowUserToDeleteRows = false;
            this.DGV_Output.AllowUserToResizeColumns = false;
            this.DGV_Output.AllowUserToResizeRows = false;
            this.DGV_Output.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Output.ColumnHeadersVisible = false;
            this.DGV_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Output.Location = new System.Drawing.Point(0, 0);
            this.DGV_Output.Name = "DGV_Output";
            this.DGV_Output.ReadOnly = true;
            this.DGV_Output.RowHeadersVisible = false;
            this.DGV_Output.RowTemplate.Height = 23;
            this.DGV_Output.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_Output.Size = new System.Drawing.Size(1128, 628);
            this.DGV_Output.TabIndex = 1;
            this.DGV_Output.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Output_CellContentClick);
            this.DGV_Output.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Output_CellMouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OutputState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV_Output);
            this.Name = "OutputState";
            this.Size = new System.Drawing.Size(1128, 628);
            this.Load += new System.EventHandler(this.InputState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Output)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Output;
        private System.Windows.Forms.Timer timer1;
    }
}
