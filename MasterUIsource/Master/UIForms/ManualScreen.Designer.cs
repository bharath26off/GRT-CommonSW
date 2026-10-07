using System.Drawing;
using System.Windows.Forms;

namespace UIForms
{
    partial class ManualScreen
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Conveyor = new System.Windows.Forms.TabPage();
            this.button25 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label222 = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.label220 = new System.Windows.Forms.Label();
            this.button49 = new System.Windows.Forms.Button();
            this.Streamline1_Start = new System.Windows.Forms.Button();
            this.PickGantry = new System.Windows.Forms.TabPage();
            this.AxisGroup = new System.Windows.Forms.GroupBox();
            this.AxisLabel = new System.Windows.Forms.Label();
            this.AxisCombo = new System.Windows.Forms.ComboBox();
            this.button17 = new System.Windows.Forms.Button();
            this.DryCycle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ScrewGantry = new System.Windows.Forms.TabPage();
            this.button24 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Screw_Gantry = new System.Windows.Forms.TabControl();
            this.AxisY1 = new System.Windows.Forms.TabPage();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.Btn_ScrewServo_Enable_X1 = new System.Windows.Forms.Button();
            this.btnScrewServoX1ClearErr = new System.Windows.Forms.Button();
            this.Btn_ScrewServo_disable_X1 = new System.Windows.Forms.Button();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.lbl_X1ScrewServo_ActualPosition = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.Targetposition_Screw_X1 = new System.Windows.Forms.Label();
            this.groupBox46 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label144 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label152 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label154 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label178 = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.groupBox47 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label184 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label185 = new System.Windows.Forms.Label();
            this.label186 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.btnScrewJogAdd_X1 = new System.Windows.Forms.Button();
            this.label187 = new System.Windows.Forms.Label();
            this.groupBox48 = new System.Windows.Forms.GroupBox();
            this.btn_X1stop_home = new System.Windows.Forms.Button();
            this.label194 = new System.Windows.Forms.Label();
            this.btnScrewHome_X1 = new System.Windows.Forms.Button();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label195 = new System.Windows.Forms.Label();
            this.groupBox49 = new System.Windows.Forms.GroupBox();
            this.btn_x1ScrewMove_stop = new System.Windows.Forms.Button();
            this.btnScrewSVMove_X1 = new System.Windows.Forms.Button();
            this.label196 = new System.Windows.Forms.Label();
            this.label197 = new System.Windows.Forms.Label();
            this.lbl_X1ScrewSV_Speed = new System.Windows.Forms.TextBox();
            this.label198 = new System.Windows.Forms.Label();
            this.lbl_X1ScrewSV_TargetPosition = new System.Windows.Forms.TextBox();
            this.label199 = new System.Windows.Forms.Label();
            this.groupBox50 = new System.Windows.Forms.GroupBox();
            this.lblScrewServoX1disable = new System.Windows.Forms.Label();
            this.label201 = new System.Windows.Forms.Label();
            this.lblScrewServoX1Error = new System.Windows.Forms.Label();
            this.label203 = new System.Windows.Forms.Label();
            this.lblScrewServoX1Positive_limit = new System.Windows.Forms.Label();
            this.label205 = new System.Windows.Forms.Label();
            this.lblScrewServoX1Home = new System.Windows.Forms.Label();
            this.lblScrewServoX1Running = new System.Windows.Forms.Label();
            this.lblScrewServoX1Ready = new System.Windows.Forms.Label();
            this.lblScrewServoX1Negative_limit = new System.Windows.Forms.Label();
            this.lblScrewServoX1Enable = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.label212 = new System.Windows.Forms.Label();
            this.label213 = new System.Windows.Forms.Label();
            this.label214 = new System.Windows.Forms.Label();
            this.label215 = new System.Windows.Forms.Label();
            this.AxisY2 = new System.Windows.Forms.TabPage();
            this.groupBox94 = new System.Windows.Forms.GroupBox();
            this.groupBox95 = new System.Windows.Forms.GroupBox();
            this.Btn_ScrewServo_Enable_X2 = new System.Windows.Forms.Button();
            this.btnScrewServoX2ClearErr = new System.Windows.Forms.Button();
            this.Btn_ScrewServo_disable_X2 = new System.Windows.Forms.Button();
            this.groupBox96 = new System.Windows.Forms.GroupBox();
            this.label396 = new System.Windows.Forms.Label();
            this.lbl_X2ScrewServo_ActualPosition = new System.Windows.Forms.Label();
            this.label400 = new System.Windows.Forms.Label();
            this.label401 = new System.Windows.Forms.Label();
            this.label402 = new System.Windows.Forms.Label();
            this.Targetposition_Screw_X2 = new System.Windows.Forms.Label();
            this.groupBox97 = new System.Windows.Forms.GroupBox();
            this.button85 = new System.Windows.Forms.Button();
            this.button86 = new System.Windows.Forms.Button();
            this.textBox70 = new System.Windows.Forms.TextBox();
            this.textBox71 = new System.Windows.Forms.TextBox();
            this.textBox72 = new System.Windows.Forms.TextBox();
            this.label404 = new System.Windows.Forms.Label();
            this.label405 = new System.Windows.Forms.Label();
            this.textBox73 = new System.Windows.Forms.TextBox();
            this.label406 = new System.Windows.Forms.Label();
            this.textBox74 = new System.Windows.Forms.TextBox();
            this.label407 = new System.Windows.Forms.Label();
            this.label412 = new System.Windows.Forms.Label();
            this.label413 = new System.Windows.Forms.Label();
            this.label414 = new System.Windows.Forms.Label();
            this.label415 = new System.Windows.Forms.Label();
            this.label416 = new System.Windows.Forms.Label();
            this.label417 = new System.Windows.Forms.Label();
            this.groupBox98 = new System.Windows.Forms.GroupBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label418 = new System.Windows.Forms.Label();
            this.textBox75 = new System.Windows.Forms.TextBox();
            this.label419 = new System.Windows.Forms.Label();
            this.label420 = new System.Windows.Forms.Label();
            this.button87 = new System.Windows.Forms.Button();
            this.button88 = new System.Windows.Forms.Button();
            this.label421 = new System.Windows.Forms.Label();
            this.groupBox99 = new System.Windows.Forms.GroupBox();
            this.btn_X2stop_home = new System.Windows.Forms.Button();
            this.label422 = new System.Windows.Forms.Label();
            this.btnScrewHome_X2 = new System.Windows.Forms.Button();
            this.textBox76 = new System.Windows.Forms.TextBox();
            this.label488 = new System.Windows.Forms.Label();
            this.groupBox100 = new System.Windows.Forms.GroupBox();
            this.btn_x2ScrewMove_stop = new System.Windows.Forms.Button();
            this.btnScrewSVMove_X2 = new System.Windows.Forms.Button();
            this.label489 = new System.Windows.Forms.Label();
            this.label490 = new System.Windows.Forms.Label();
            this.lbl_X2ScrewSV_Speed = new System.Windows.Forms.TextBox();
            this.label491 = new System.Windows.Forms.Label();
            this.txt_targetposition_ScrewX2 = new System.Windows.Forms.TextBox();
            this.label492 = new System.Windows.Forms.Label();
            this.groupBox101 = new System.Windows.Forms.GroupBox();
            this.lblScrewServoX2disable = new System.Windows.Forms.Label();
            this.label494 = new System.Windows.Forms.Label();
            this.lblScrewServoX2Error = new System.Windows.Forms.Label();
            this.label496 = new System.Windows.Forms.Label();
            this.lblScrewServoX2Positive_limit = new System.Windows.Forms.Label();
            this.label498 = new System.Windows.Forms.Label();
            this.lblScrewServoX2Home = new System.Windows.Forms.Label();
            this.lblScrewServoX2Running = new System.Windows.Forms.Label();
            this.lblScrewServoX2Ready = new System.Windows.Forms.Label();
            this.lblScrewServoX2Negative_limit = new System.Windows.Forms.Label();
            this.lblScrewServoX2Enable = new System.Windows.Forms.Label();
            this.label504 = new System.Windows.Forms.Label();
            this.label505 = new System.Windows.Forms.Label();
            this.label506 = new System.Windows.Forms.Label();
            this.label507 = new System.Windows.Forms.Label();
            this.label508 = new System.Windows.Forms.Label();
            this.AxisX1 = new System.Windows.Forms.TabPage();
            this.groupBox51 = new System.Windows.Forms.GroupBox();
            this.groupBox52 = new System.Windows.Forms.GroupBox();
            this.Btn_ScrewServo_Enable_Y1 = new System.Windows.Forms.Button();
            this.btnScrewServoY1ClearErr = new System.Windows.Forms.Button();
            this.Btn_ScrewServo_disable_Y1 = new System.Windows.Forms.Button();
            this.groupBox61 = new System.Windows.Forms.GroupBox();
            this.label216 = new System.Windows.Forms.Label();
            this.lbl_Y1ScrewServo_ActualPosition = new System.Windows.Forms.Label();
            this.label218 = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.lbl_Y1ScrewSV_TP = new System.Windows.Forms.Label();
            this.groupBox62 = new System.Windows.Forms.GroupBox();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.label225 = new System.Windows.Forms.Label();
            this.label226 = new System.Windows.Forms.Label();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.label227 = new System.Windows.Forms.Label();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.label228 = new System.Windows.Forms.Label();
            this.label230 = new System.Windows.Forms.Label();
            this.label231 = new System.Windows.Forms.Label();
            this.label232 = new System.Windows.Forms.Label();
            this.label233 = new System.Windows.Forms.Label();
            this.label234 = new System.Windows.Forms.Label();
            this.label235 = new System.Windows.Forms.Label();
            this.groupBox63 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label236 = new System.Windows.Forms.Label();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.label237 = new System.Windows.Forms.Label();
            this.label238 = new System.Windows.Forms.Label();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.label239 = new System.Windows.Forms.Label();
            this.groupBox64 = new System.Windows.Forms.GroupBox();
            this.btn_Y1stop_home = new System.Windows.Forms.Button();
            this.label240 = new System.Windows.Forms.Label();
            this.btnScrewHome_Y1 = new System.Windows.Forms.Button();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.label241 = new System.Windows.Forms.Label();
            this.groupBox65 = new System.Windows.Forms.GroupBox();
            this.button32 = new System.Windows.Forms.Button();
            this.btnScrewSVMove_Y1 = new System.Windows.Forms.Button();
            this.label243 = new System.Windows.Forms.Label();
            this.label244 = new System.Windows.Forms.Label();
            this.lbl_Y1ScrewSV_Speed = new System.Windows.Forms.TextBox();
            this.label245 = new System.Windows.Forms.Label();
            this.lbl_Y1ScrewSV_TargetPosition = new System.Windows.Forms.TextBox();
            this.label246 = new System.Windows.Forms.Label();
            this.groupBox66 = new System.Windows.Forms.GroupBox();
            this.lblScrewServoY1disable = new System.Windows.Forms.Label();
            this.label268 = new System.Windows.Forms.Label();
            this.lblScrewServoY1Error = new System.Windows.Forms.Label();
            this.label272 = new System.Windows.Forms.Label();
            this.lblScrewServoY1Home = new System.Windows.Forms.Label();
            this.lblScrewServoY1Running = new System.Windows.Forms.Label();
            this.lblScrewServoY1Ready = new System.Windows.Forms.Label();
            this.lblScrewServoY1Enable = new System.Windows.Forms.Label();
            this.label285 = new System.Windows.Forms.Label();
            this.label286 = new System.Windows.Forms.Label();
            this.label288 = new System.Windows.Forms.Label();
            this.label289 = new System.Windows.Forms.Label();
            this.AxisX2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.lblActPosAX2 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.label84 = new System.Windows.Forms.Label();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label87 = new System.Windows.Forms.Label();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label88 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.groupBox79 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.label106 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.txtTargSpdAX2 = new System.Windows.Forms.TextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.txtTargPosAX2 = new System.Windows.Forms.TextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.groupBox80 = new System.Windows.Forms.GroupBox();
            this.txtAX2Disable = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.txtAX2Enable = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.label202 = new System.Windows.Forms.Label();
            this.label204 = new System.Windows.Forms.Label();
            this.AxisZ1 = new System.Windows.Forms.TabPage();
            this.groupBox67 = new System.Windows.Forms.GroupBox();
            this.groupBox68 = new System.Windows.Forms.GroupBox();
            this.Btn_ScrewServo_Enable_Z1 = new System.Windows.Forms.Button();
            this.btnScrewServoZ1ClearErr = new System.Windows.Forms.Button();
            this.Btn_ScrewServo_disable_Z1 = new System.Windows.Forms.Button();
            this.groupBox69 = new System.Windows.Forms.GroupBox();
            this.lbl_Z1ScrewSV_TP = new System.Windows.Forms.Label();
            this.label291 = new System.Windows.Forms.Label();
            this.label292 = new System.Windows.Forms.Label();
            this.lbl_Z1ScrewServo_ActualPosition = new System.Windows.Forms.Label();
            this.label294 = new System.Windows.Forms.Label();
            this.label295 = new System.Windows.Forms.Label();
            this.groupBox70 = new System.Windows.Forms.GroupBox();
            this.button39 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.textBox45 = new System.Windows.Forms.TextBox();
            this.textBox48 = new System.Windows.Forms.TextBox();
            this.textBox50 = new System.Windows.Forms.TextBox();
            this.label296 = new System.Windows.Forms.Label();
            this.label297 = new System.Windows.Forms.Label();
            this.textBox51 = new System.Windows.Forms.TextBox();
            this.label298 = new System.Windows.Forms.Label();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.label299 = new System.Windows.Forms.Label();
            this.label300 = new System.Windows.Forms.Label();
            this.label301 = new System.Windows.Forms.Label();
            this.label302 = new System.Windows.Forms.Label();
            this.label303 = new System.Windows.Forms.Label();
            this.label304 = new System.Windows.Forms.Label();
            this.label305 = new System.Windows.Forms.Label();
            this.groupBox71 = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label306 = new System.Windows.Forms.Label();
            this.textBox53 = new System.Windows.Forms.TextBox();
            this.label307 = new System.Windows.Forms.Label();
            this.label308 = new System.Windows.Forms.Label();
            this.button41 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.label309 = new System.Windows.Forms.Label();
            this.groupBox72 = new System.Windows.Forms.GroupBox();
            this.button43 = new System.Windows.Forms.Button();
            this.label310 = new System.Windows.Forms.Label();
            this.btnScrewHome_Z1 = new System.Windows.Forms.Button();
            this.textBox54 = new System.Windows.Forms.TextBox();
            this.label311 = new System.Windows.Forms.Label();
            this.groupBox73 = new System.Windows.Forms.GroupBox();
            this.btn_Z1ScrewMove_stop = new System.Windows.Forms.Button();
            this.btnScrewSVMove_Z1 = new System.Windows.Forms.Button();
            this.label322 = new System.Windows.Forms.Label();
            this.label323 = new System.Windows.Forms.Label();
            this.lbl_Z1ScrewSV_TargetSpeed = new System.Windows.Forms.TextBox();
            this.label324 = new System.Windows.Forms.Label();
            this.lbl_Z1ScrewSV_TargetPosition = new System.Windows.Forms.TextBox();
            this.label325 = new System.Windows.Forms.Label();
            this.groupBox74 = new System.Windows.Forms.GroupBox();
            this.lblScrewServoZ1disable = new System.Windows.Forms.Label();
            this.label327 = new System.Windows.Forms.Label();
            this.lblScrewServoZ1Error = new System.Windows.Forms.Label();
            this.label329 = new System.Windows.Forms.Label();
            this.lblScrewServoZ1Positive_limit = new System.Windows.Forms.Label();
            this.label331 = new System.Windows.Forms.Label();
            this.lblScrewServoZ1Home = new System.Windows.Forms.Label();
            this.lblScrewServoZ1Running = new System.Windows.Forms.Label();
            this.lblScrewServoZ1Ready = new System.Windows.Forms.Label();
            this.lblScrewServoZ1Negative_limit = new System.Windows.Forms.Label();
            this.lblScrewServoZ1Enable = new System.Windows.Forms.Label();
            this.label337 = new System.Windows.Forms.Label();
            this.label338 = new System.Windows.Forms.Label();
            this.label339 = new System.Windows.Forms.Label();
            this.label340 = new System.Windows.Forms.Label();
            this.label341 = new System.Windows.Forms.Label();
            this.AxisZ2 = new System.Windows.Forms.TabPage();
            this.groupBox75 = new System.Windows.Forms.GroupBox();
            this.groupBox76 = new System.Windows.Forms.GroupBox();
            this.Btn_ScrewServo_Enable_Z2 = new System.Windows.Forms.Button();
            this.btnScrewServoZ2ClearErr = new System.Windows.Forms.Button();
            this.Btn_ScrewServo_disable_Z2 = new System.Windows.Forms.Button();
            this.groupBox77 = new System.Windows.Forms.GroupBox();
            this.lbl_Z2ScrewSV_TP = new System.Windows.Forms.Label();
            this.label344 = new System.Windows.Forms.Label();
            this.label345 = new System.Windows.Forms.Label();
            this.lbl_Z2Servo_ActualPosition = new System.Windows.Forms.Label();
            this.label347 = new System.Windows.Forms.Label();
            this.label348 = new System.Windows.Forms.Label();
            this.groupBox78 = new System.Windows.Forms.GroupBox();
            this.button74 = new System.Windows.Forms.Button();
            this.button75 = new System.Windows.Forms.Button();
            this.textBox60 = new System.Windows.Forms.TextBox();
            this.textBox61 = new System.Windows.Forms.TextBox();
            this.textBox62 = new System.Windows.Forms.TextBox();
            this.label349 = new System.Windows.Forms.Label();
            this.label350 = new System.Windows.Forms.Label();
            this.textBox63 = new System.Windows.Forms.TextBox();
            this.label351 = new System.Windows.Forms.Label();
            this.textBox64 = new System.Windows.Forms.TextBox();
            this.label352 = new System.Windows.Forms.Label();
            this.label353 = new System.Windows.Forms.Label();
            this.label354 = new System.Windows.Forms.Label();
            this.label355 = new System.Windows.Forms.Label();
            this.label357 = new System.Windows.Forms.Label();
            this.label358 = new System.Windows.Forms.Label();
            this.label359 = new System.Windows.Forms.Label();
            this.groupBox83 = new System.Windows.Forms.GroupBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label360 = new System.Windows.Forms.Label();
            this.textBox65 = new System.Windows.Forms.TextBox();
            this.label361 = new System.Windows.Forms.Label();
            this.label364 = new System.Windows.Forms.Label();
            this.button76 = new System.Windows.Forms.Button();
            this.button77 = new System.Windows.Forms.Button();
            this.label365 = new System.Windows.Forms.Label();
            this.groupBox86 = new System.Windows.Forms.GroupBox();
            this.btn_Z2stop_home = new System.Windows.Forms.Button();
            this.label366 = new System.Windows.Forms.Label();
            this.btnScrewHome_Z2 = new System.Windows.Forms.Button();
            this.textBox66 = new System.Windows.Forms.TextBox();
            this.label367 = new System.Windows.Forms.Label();
            this.groupBox88 = new System.Windows.Forms.GroupBox();
            this.btn_Z2ScrewMove_stop = new System.Windows.Forms.Button();
            this.btnScrewSVMove_Z2 = new System.Windows.Forms.Button();
            this.label368 = new System.Windows.Forms.Label();
            this.label369 = new System.Windows.Forms.Label();
            this.lbl_Z2ScrewSV_TargetSpeed = new System.Windows.Forms.TextBox();
            this.label370 = new System.Windows.Forms.Label();
            this.lbl_Z2ScrewSV_TargetPosition = new System.Windows.Forms.TextBox();
            this.label371 = new System.Windows.Forms.Label();
            this.groupBox93 = new System.Windows.Forms.GroupBox();
            this.lblScrewServoZ2disable = new System.Windows.Forms.Label();
            this.label373 = new System.Windows.Forms.Label();
            this.lblScrewServoZ2Error = new System.Windows.Forms.Label();
            this.label375 = new System.Windows.Forms.Label();
            this.lblScrewServoZ2Positive_limit = new System.Windows.Forms.Label();
            this.label377 = new System.Windows.Forms.Label();
            this.lblScrewServoZ2Home = new System.Windows.Forms.Label();
            this.lblScrewServoZ2Running = new System.Windows.Forms.Label();
            this.lblScrewServoZ2Ready = new System.Windows.Forms.Label();
            this.lblScrewServoZ2Negative_limit = new System.Windows.Forms.Label();
            this.lblScrewServoZ2Enable = new System.Windows.Forms.Label();
            this.label383 = new System.Windows.Forms.Label();
            this.label384 = new System.Windows.Forms.Label();
            this.label385 = new System.Windows.Forms.Label();
            this.label390 = new System.Windows.Forms.Label();
            this.label391 = new System.Windows.Forms.Label();
            this.Feeder = new System.Windows.Forms.TabPage();
            this.button18 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.tabFeeder = new System.Windows.Forms.TabControl();
            this.Loader = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBreakEnable_Loader = new System.Windows.Forms.Button();
            this.btnBreakDisable_Loader = new System.Windows.Forms.Button();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.btnServoLoaderEnable = new System.Windows.Forms.Button();
            this.btnServoLoaderClearErr = new System.Windows.Forms.Button();
            this.btnServoLoaderDisable = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.label107 = new System.Windows.Forms.Label();
            this.lbl_loader_ActualPosition = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.lbl_loader_ActualVelocity = new System.Windows.Forms.Label();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.btnLoader_Stop = new System.Windows.Forms.Button();
            this.btnLoader_Move_point = new System.Windows.Forms.Button();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label117 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.txtJogVelocity_LHloader = new System.Windows.Forms.ComboBox();
            this.label125 = new System.Windows.Forms.Label();
            this.txtJogDist_LHloader = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.btnJogDec_Loader = new System.Windows.Forms.Button();
            this.btnJogAdd_Loader = new System.Windows.Forms.Button();
            this.label128 = new System.Windows.Forms.Label();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.btnHome_Stop_Loader = new System.Windows.Forms.Button();
            this.label129 = new System.Windows.Forms.Label();
            this.btnHome_Loader = new System.Windows.Forms.Button();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.label130 = new System.Windows.Forms.Label();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.btnMove_Stop_Loader = new System.Windows.Forms.Button();
            this.btnMove_Loader = new System.Windows.Forms.Button();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.txtLHLoader_TargetSpeed = new System.Windows.Forms.TextBox();
            this.label133 = new System.Windows.Forms.Label();
            this.txtLHLoader_Targetposition = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.lblServoDisableloader = new System.Windows.Forms.Label();
            this.label188 = new System.Windows.Forms.Label();
            this.lblServoloader_Error = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.lblServoloader_PositiveLimit = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.lblServoloader_Home = new System.Windows.Forms.Label();
            this.lblServoloader_Running = new System.Windows.Forms.Label();
            this.lblServoloader_Ready = new System.Windows.Forms.Label();
            this.lblServoloader_NegativeLimit = new System.Windows.Forms.Label();
            this.lblServoloader_Enable = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.Unloader = new System.Windows.Forms.TabPage();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.groupBox53 = new System.Windows.Forms.GroupBox();
            this.btnUnloader_BreakEnable = new System.Windows.Forms.Button();
            this.btnUnloader_BreakDisable = new System.Windows.Forms.Button();
            this.groupBox54 = new System.Windows.Forms.GroupBox();
            this.btnUnloader_ServoEnable = new System.Windows.Forms.Button();
            this.btnUnloader_ServoClearErr = new System.Windows.Forms.Button();
            this.btnUnloader_ServoDisable = new System.Windows.Forms.Button();
            this.groupBox55 = new System.Windows.Forms.GroupBox();
            this.label151 = new System.Windows.Forms.Label();
            this.lblUnloader_ActualPosition = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.lblUnloader_ActualVelocity = new System.Windows.Forms.Label();
            this.groupBox56 = new System.Windows.Forms.GroupBox();
            this.btnUnloader_Stop = new System.Windows.Forms.Button();
            this.btnUnloader_Move_point = new System.Windows.Forms.Button();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.label248 = new System.Windows.Forms.Label();
            this.label249 = new System.Windows.Forms.Label();
            this.textBox46 = new System.Windows.Forms.TextBox();
            this.label250 = new System.Windows.Forms.Label();
            this.textBox47 = new System.Windows.Forms.TextBox();
            this.label251 = new System.Windows.Forms.Label();
            this.label252 = new System.Windows.Forms.Label();
            this.label253 = new System.Windows.Forms.Label();
            this.label254 = new System.Windows.Forms.Label();
            this.label255 = new System.Windows.Forms.Label();
            this.label256 = new System.Windows.Forms.Label();
            this.label257 = new System.Windows.Forms.Label();
            this.groupBox57 = new System.Windows.Forms.GroupBox();
            this.txtJogVelocity_LHUnloader = new System.Windows.Forms.ComboBox();
            this.label258 = new System.Windows.Forms.Label();
            this.txtJogDist_LHUnloader = new System.Windows.Forms.TextBox();
            this.label259 = new System.Windows.Forms.Label();
            this.label260 = new System.Windows.Forms.Label();
            this.btnJogDec_Unloader = new System.Windows.Forms.Button();
            this.btnJogAdd_Unloader = new System.Windows.Forms.Button();
            this.label261 = new System.Windows.Forms.Label();
            this.groupBox58 = new System.Windows.Forms.GroupBox();
            this.btnUnloader_Home_Stop = new System.Windows.Forms.Button();
            this.label262 = new System.Windows.Forms.Label();
            this.btnUnloader_Home = new System.Windows.Forms.Button();
            this.textBox49 = new System.Windows.Forms.TextBox();
            this.label263 = new System.Windows.Forms.Label();
            this.groupBox59 = new System.Windows.Forms.GroupBox();
            this.btnUnloader_Stop_Move = new System.Windows.Forms.Button();
            this.btnUnloader_Move = new System.Windows.Forms.Button();
            this.label264 = new System.Windows.Forms.Label();
            this.label265 = new System.Windows.Forms.Label();
            this.txtLHUnLoader_TargetSpeed = new System.Windows.Forms.TextBox();
            this.label266 = new System.Windows.Forms.Label();
            this.txtLHUnLoader_Targetposition = new System.Windows.Forms.TextBox();
            this.label267 = new System.Windows.Forms.Label();
            this.groupBox60 = new System.Windows.Forms.GroupBox();
            this.lblServoDisableUnloader = new System.Windows.Forms.Label();
            this.label242 = new System.Windows.Forms.Label();
            this.lblUnloader_Error = new System.Windows.Forms.Label();
            this.label270 = new System.Windows.Forms.Label();
            this.lblUnloader_PositiveLimit = new System.Windows.Forms.Label();
            this.label271 = new System.Windows.Forms.Label();
            this.lblUnloader_Home = new System.Windows.Forms.Label();
            this.lblUnloader_Running = new System.Windows.Forms.Label();
            this.lblUnloader_Ready = new System.Windows.Forms.Label();
            this.lblUnloader_NegativeLimit = new System.Windows.Forms.Label();
            this.lblUnloader_Enable = new System.Windows.Forms.Label();
            this.label279 = new System.Windows.Forms.Label();
            this.label280 = new System.Windows.Forms.Label();
            this.label281 = new System.Windows.Forms.Label();
            this.label282 = new System.Windows.Forms.Label();
            this.label283 = new System.Windows.Forms.Label();
            this.Shuttle = new System.Windows.Forms.TabPage();
            this.button31 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.InternalShuttle = new System.Windows.Forms.TabControl();
            this.Shuttle1 = new System.Windows.Forms.TabPage();
            this.groupBox82 = new System.Windows.Forms.GroupBox();
            this.groupBox85 = new System.Windows.Forms.GroupBox();
            this.btnShuttle1Enable = new System.Windows.Forms.Button();
            this.btnShuttle1ClearErr = new System.Windows.Forms.Button();
            this.btnShuttle1Disable = new System.Windows.Forms.Button();
            this.groupBox87 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.lbl_Sh1_ActualPosition = new System.Windows.Forms.Label();
            this.label356 = new System.Windows.Forms.Label();
            this.label362 = new System.Windows.Forms.Label();
            this.label363 = new System.Windows.Forms.Label();
            this.lbl_Shuttle1_TargetPosition = new System.Windows.Forms.Label();
            this.groupBox89 = new System.Windows.Forms.GroupBox();
            this.btnStopPointS1 = new System.Windows.Forms.Button();
            this.btnMovePointS1 = new System.Windows.Forms.Button();
            this.textBox68 = new System.Windows.Forms.TextBox();
            this.textBox79 = new System.Windows.Forms.TextBox();
            this.textBox80 = new System.Windows.Forms.TextBox();
            this.label387 = new System.Windows.Forms.Label();
            this.label388 = new System.Windows.Forms.Label();
            this.textBox81 = new System.Windows.Forms.TextBox();
            this.label389 = new System.Windows.Forms.Label();
            this.textBox82 = new System.Windows.Forms.TextBox();
            this.label392 = new System.Windows.Forms.Label();
            this.label393 = new System.Windows.Forms.Label();
            this.label394 = new System.Windows.Forms.Label();
            this.label395 = new System.Windows.Forms.Label();
            this.label397 = new System.Windows.Forms.Label();
            this.label399 = new System.Windows.Forms.Label();
            this.label408 = new System.Windows.Forms.Label();
            this.groupBox90 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label409 = new System.Windows.Forms.Label();
            this.textBox83 = new System.Windows.Forms.TextBox();
            this.label410 = new System.Windows.Forms.Label();
            this.label411 = new System.Windows.Forms.Label();
            this.btnJogDecS1 = new System.Windows.Forms.Button();
            this.btnJogAddS1 = new System.Windows.Forms.Button();
            this.label423 = new System.Windows.Forms.Label();
            this.groupBox91 = new System.Windows.Forms.GroupBox();
            this.btnHomeStopS1 = new System.Windows.Forms.Button();
            this.label424 = new System.Windows.Forms.Label();
            this.btnHomeS1 = new System.Windows.Forms.Button();
            this.textBox84 = new System.Windows.Forms.TextBox();
            this.label425 = new System.Windows.Forms.Label();
            this.groupBox92 = new System.Windows.Forms.GroupBox();
            this.btnMotionStopS1 = new System.Windows.Forms.Button();
            this.btnMotionMoveS1 = new System.Windows.Forms.Button();
            this.label426 = new System.Windows.Forms.Label();
            this.label427 = new System.Windows.Forms.Label();
            this.txtShuttle1_TargetSpeed = new System.Windows.Forms.TextBox();
            this.label428 = new System.Windows.Forms.Label();
            this.txtServoS1_Targetposition = new System.Windows.Forms.TextBox();
            this.label429 = new System.Windows.Forms.Label();
            this.groupBox102 = new System.Windows.Forms.GroupBox();
            this.lblSh1servoEnable = new System.Windows.Forms.Label();
            this.lblSh1servo_PositiveLimit = new System.Windows.Forms.Label();
            this.label431 = new System.Windows.Forms.Label();
            this.lblSh1servo_NegativeLimit = new System.Windows.Forms.Label();
            this.label433 = new System.Windows.Forms.Label();
            this.lblSh1servoDisable = new System.Windows.Forms.Label();
            this.label435 = new System.Windows.Forms.Label();
            this.lblSh1servo_Error = new System.Windows.Forms.Label();
            this.label437 = new System.Windows.Forms.Label();
            this.lblSh1servo_Home = new System.Windows.Forms.Label();
            this.label439 = new System.Windows.Forms.Label();
            this.label440 = new System.Windows.Forms.Label();
            this.label442 = new System.Windows.Forms.Label();
            this.label443 = new System.Windows.Forms.Label();
            this.label444 = new System.Windows.Forms.Label();
            this.label445 = new System.Windows.Forms.Label();
            this.Shuttle2 = new System.Windows.Forms.TabPage();
            this.groupBox103 = new System.Windows.Forms.GroupBox();
            this.groupBox112 = new System.Windows.Forms.GroupBox();
            this.btnShuttle2Enable = new System.Windows.Forms.Button();
            this.btnShuttle2ClearErr = new System.Windows.Forms.Button();
            this.btnShuttle2Disable = new System.Windows.Forms.Button();
            this.groupBox106 = new System.Windows.Forms.GroupBox();
            this.label446 = new System.Windows.Forms.Label();
            this.lbl_Sh2_ActualPosition = new System.Windows.Forms.Label();
            this.label448 = new System.Windows.Forms.Label();
            this.label449 = new System.Windows.Forms.Label();
            this.label450 = new System.Windows.Forms.Label();
            this.lbl_Shuttle2_TargetPosition = new System.Windows.Forms.Label();
            this.groupBox107 = new System.Windows.Forms.GroupBox();
            this.btnStopPointS2 = new System.Windows.Forms.Button();
            this.btnMovePointS2 = new System.Windows.Forms.Button();
            this.textBox87 = new System.Windows.Forms.TextBox();
            this.textBox88 = new System.Windows.Forms.TextBox();
            this.textBox89 = new System.Windows.Forms.TextBox();
            this.label452 = new System.Windows.Forms.Label();
            this.label453 = new System.Windows.Forms.Label();
            this.textBox90 = new System.Windows.Forms.TextBox();
            this.label454 = new System.Windows.Forms.Label();
            this.textBox91 = new System.Windows.Forms.TextBox();
            this.label455 = new System.Windows.Forms.Label();
            this.label456 = new System.Windows.Forms.Label();
            this.label457 = new System.Windows.Forms.Label();
            this.label458 = new System.Windows.Forms.Label();
            this.label459 = new System.Windows.Forms.Label();
            this.label460 = new System.Windows.Forms.Label();
            this.label461 = new System.Windows.Forms.Label();
            this.groupBox108 = new System.Windows.Forms.GroupBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label462 = new System.Windows.Forms.Label();
            this.textBox92 = new System.Windows.Forms.TextBox();
            this.label463 = new System.Windows.Forms.Label();
            this.label464 = new System.Windows.Forms.Label();
            this.btnJogDecS2 = new System.Windows.Forms.Button();
            this.btnJogAddS2 = new System.Windows.Forms.Button();
            this.label465 = new System.Windows.Forms.Label();
            this.groupBox109 = new System.Windows.Forms.GroupBox();
            this.btnHomeStopS2 = new System.Windows.Forms.Button();
            this.label466 = new System.Windows.Forms.Label();
            this.btnHomeS2 = new System.Windows.Forms.Button();
            this.textBox93 = new System.Windows.Forms.TextBox();
            this.label467 = new System.Windows.Forms.Label();
            this.groupBox110 = new System.Windows.Forms.GroupBox();
            this.btnMotionStopS2 = new System.Windows.Forms.Button();
            this.btnMotionMoveS2 = new System.Windows.Forms.Button();
            this.label468 = new System.Windows.Forms.Label();
            this.label469 = new System.Windows.Forms.Label();
            this.txtShuttle2_TargetSpeed = new System.Windows.Forms.TextBox();
            this.label470 = new System.Windows.Forms.Label();
            this.txtServoS2_Targetposition = new System.Windows.Forms.TextBox();
            this.label471 = new System.Windows.Forms.Label();
            this.groupBox111 = new System.Windows.Forms.GroupBox();
            this.lblSh2servo_PositiveLimit = new System.Windows.Forms.Label();
            this.label473 = new System.Windows.Forms.Label();
            this.lblSh2servo_NegativeLimit = new System.Windows.Forms.Label();
            this.label475 = new System.Windows.Forms.Label();
            this.lblSh2servoDisable = new System.Windows.Forms.Label();
            this.label477 = new System.Windows.Forms.Label();
            this.lblSh2servo_Error = new System.Windows.Forms.Label();
            this.label479 = new System.Windows.Forms.Label();
            this.lblSh2servo_Home = new System.Windows.Forms.Label();
            this.label481 = new System.Windows.Forms.Label();
            this.label482 = new System.Windows.Forms.Label();
            this.lblSh2servoenable = new System.Windows.Forms.Label();
            this.label484 = new System.Windows.Forms.Label();
            this.label485 = new System.Windows.Forms.Label();
            this.label486 = new System.Windows.Forms.Label();
            this.label487 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageAxis = new System.Windows.Forms.TabPage();
            this.ServosettingsPanel = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.lblServoHomedColor = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblServoErrorColor = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lblPosLimColor = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lblServoHomeColor = new System.Windows.Forms.Label();
            this.lblServoRunningColor = new System.Windows.Forms.Label();
            this.lblNegLimitColor = new System.Windows.Forms.Label();
            this.lblServoEnableColor = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.grbPTP = new System.Windows.Forms.GroupBox();
            this.btnPTP_Stop = new System.Windows.Forms.Button();
            this.btnPTP_Move = new System.Windows.Forms.Button();
            this.txtIteration = new System.Windows.Forms.TextBox();
            this.txtWait = new System.Windows.Forms.TextBox();
            this.txtPTP_Speed = new System.Windows.Forms.TextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.txtPTP_End = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.txtPTP_Start = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnServoEnable = new System.Windows.Forms.Button();
            this.btnServoClear = new System.Windows.Forms.Button();
            this.btnServoDisable = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Servo_Actual_Position = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_Servo_TargetPosition = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJogSpeed = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnJogReverse = new System.Windows.Forms.Button();
            this.btnJogForward = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnHomeStop = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.txtHome_Velocity = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnMoveStop = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtServoX_Targetspeed = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtServoX_Targetposition = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.AxisSelectPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.AxisSelectCombo = new System.Windows.Forms.ComboBox();
            this.tabPageStepper = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.grp_IO_Conv = new System.Windows.Forms.GroupBox();
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.Conv_Status = new System.Windows.Forms.TextBox();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.Conv_Reset = new System.Windows.Forms.Button();
            this.Conv_Reverse = new System.Windows.Forms.Button();
            this.Conv_Stop = new System.Windows.Forms.Button();
            this.Conv_Forward = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.lblServoErrorColor_Stp = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblServoEnableColor_Stp = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.grp_IO_Conv_Stepper_2 = new System.Windows.Forms.GroupBox();
            this.StpperServo_On = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.grp_IO_Conv_Stepper_1 = new System.Windows.Forms.GroupBox();
            this.button20 = new System.Windows.Forms.Button();
            this.label80 = new System.Windows.Forms.Label();
            this.stp_Text = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.button44 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.StepperAxisComb = new System.Windows.Forms.ComboBox();
            this.tabPageCylinder = new System.Windows.Forms.TabPage();
            this.PnlCylinderMain = new System.Windows.Forms.Panel();
            this.tabPageVacuum = new System.Windows.Forms.TabPage();
            this.PnlVacuumMain = new System.Windows.Forms.Panel();
            this.tabPageRobot = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpRoboConn = new System.Windows.Forms.GroupBox();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.lblCmd = new System.Windows.Forms.Label();
            this.cmbRBTmodeselect = new System.Windows.Forms.ComboBox();
            this.lblrobotconnstatus = new System.Windows.Forms.Label();
            this.lblConnStatus = new System.Windows.Forms.Label();
            this.btnconnect = new System.Windows.Forms.Button();
            this.txtsendrobotcommand = new System.Windows.Forms.RichTextBox();
            this.txtreceivecommnd = new System.Windows.Forms.RichTextBox();
            this.label374 = new System.Windows.Forms.Label();
            this.btnRBTtrigger = new System.Windows.Forms.Button();
            this.label376 = new System.Windows.Forms.Label();
            this.tabPageCamera = new System.Windows.Forms.TabPage();
            this.grpCCDConn = new System.Windows.Forms.GroupBox();
            this.btnCamDisConnect = new System.Windows.Forms.Button();
            this.lblSelectCCD = new System.Windows.Forms.Label();
            this.cmbCCD = new System.Windows.Forms.ComboBox();
            this.lblCCDConnStatus = new System.Windows.Forms.Label();
            this.btnCCDConnect = new System.Windows.Forms.Button();
            this.txtSendCmd = new System.Windows.Forms.RichTextBox();
            this.txtRecivdCmd = new System.Windows.Forms.RichTextBox();
            this.label372 = new System.Windows.Forms.Label();
            this.btnCCDTrigger = new System.Windows.Forms.Button();
            this.lblCCDConn = new System.Windows.Forms.Label();
            this.label378 = new System.Windows.Forms.Label();
            this.tabPageLightControl = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCOMPort = new System.Windows.Forms.ComboBox();
            this.btnOPTDisconnect = new System.Windows.Forms.Button();
            this.cmbOPTSend = new System.Windows.Forms.ComboBox();
            this.lblOPTConStatus = new System.Windows.Forms.Label();
            this.btnOPTConnect = new System.Windows.Forms.Button();
            this.rtReceiveOPT = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnOPTTrigger = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPageScanner = new System.Windows.Forms.TabPage();
            this.grpScanner = new System.Windows.Forms.GroupBox();
            this.btnScnrDisconnect = new System.Windows.Forms.Button();
            this.lblScannerSel = new System.Windows.Forms.Label();
            this.cmbScanner = new System.Windows.Forms.ComboBox();
            this.lblScanrConStatus = new System.Windows.Forms.Label();
            this.btnScannerConnect = new System.Windows.Forms.Button();
            this.txtScannerSend = new System.Windows.Forms.RichTextBox();
            this.txtScannerRecieve = new System.Windows.Forms.RichTextBox();
            this.label380 = new System.Windows.Forms.Label();
            this.btnScannerTrigger = new System.Windows.Forms.Button();
            this.lblScannerConn = new System.Windows.Forms.Label();
            this.label382 = new System.Windows.Forms.Label();
            this.tabPageSfcPdca = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnPDCATrigger = new System.Windows.Forms.Button();
            this.rtSendPDCA = new System.Windows.Forms.RichTextBox();
            this.rtReceivePDCA = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSFCDisConnect = new System.Windows.Forms.Button();
            this.lblSFCConStatus = new System.Windows.Forms.Label();
            this.btnSFCConnect = new System.Windows.Forms.Button();
            this.rtSendSFC = new System.Windows.Forms.RichTextBox();
            this.rtReceiveSFC = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSFCTrigger = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbConveyorStepperCombo = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.Conveyor.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.PickGantry.SuspendLayout();
            this.ScrewGantry.SuspendLayout();
            this.Screw_Gantry.SuspendLayout();
            this.AxisY1.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox44.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.groupBox49.SuspendLayout();
            this.groupBox50.SuspendLayout();
            this.AxisY2.SuspendLayout();
            this.groupBox94.SuspendLayout();
            this.groupBox95.SuspendLayout();
            this.groupBox96.SuspendLayout();
            this.groupBox97.SuspendLayout();
            this.groupBox98.SuspendLayout();
            this.groupBox99.SuspendLayout();
            this.groupBox100.SuspendLayout();
            this.groupBox101.SuspendLayout();
            this.AxisX1.SuspendLayout();
            this.groupBox51.SuspendLayout();
            this.groupBox52.SuspendLayout();
            this.groupBox61.SuspendLayout();
            this.groupBox62.SuspendLayout();
            this.groupBox63.SuspendLayout();
            this.groupBox64.SuspendLayout();
            this.groupBox65.SuspendLayout();
            this.groupBox66.SuspendLayout();
            this.AxisX2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox79.SuspendLayout();
            this.groupBox80.SuspendLayout();
            this.AxisZ1.SuspendLayout();
            this.groupBox67.SuspendLayout();
            this.groupBox68.SuspendLayout();
            this.groupBox69.SuspendLayout();
            this.groupBox70.SuspendLayout();
            this.groupBox71.SuspendLayout();
            this.groupBox72.SuspendLayout();
            this.groupBox73.SuspendLayout();
            this.groupBox74.SuspendLayout();
            this.AxisZ2.SuspendLayout();
            this.groupBox75.SuspendLayout();
            this.groupBox76.SuspendLayout();
            this.groupBox77.SuspendLayout();
            this.groupBox78.SuspendLayout();
            this.groupBox83.SuspendLayout();
            this.groupBox86.SuspendLayout();
            this.groupBox88.SuspendLayout();
            this.groupBox93.SuspendLayout();
            this.Feeder.SuspendLayout();
            this.tabFeeder.SuspendLayout();
            this.Loader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.Unloader.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox53.SuspendLayout();
            this.groupBox54.SuspendLayout();
            this.groupBox55.SuspendLayout();
            this.groupBox56.SuspendLayout();
            this.groupBox57.SuspendLayout();
            this.groupBox58.SuspendLayout();
            this.groupBox59.SuspendLayout();
            this.groupBox60.SuspendLayout();
            this.Shuttle.SuspendLayout();
            this.InternalShuttle.SuspendLayout();
            this.Shuttle1.SuspendLayout();
            this.groupBox82.SuspendLayout();
            this.groupBox85.SuspendLayout();
            this.groupBox87.SuspendLayout();
            this.groupBox89.SuspendLayout();
            this.groupBox90.SuspendLayout();
            this.groupBox91.SuspendLayout();
            this.groupBox92.SuspendLayout();
            this.groupBox102.SuspendLayout();
            this.Shuttle2.SuspendLayout();
            this.groupBox103.SuspendLayout();
            this.groupBox112.SuspendLayout();
            this.groupBox106.SuspendLayout();
            this.groupBox107.SuspendLayout();
            this.groupBox108.SuspendLayout();
            this.groupBox109.SuspendLayout();
            this.groupBox110.SuspendLayout();
            this.groupBox111.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageAxis.SuspendLayout();
            this.ServosettingsPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.grbPTP.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.AxisSelectPanel.SuspendLayout();
            this.tabPageStepper.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.grp_IO_Conv.SuspendLayout();
            this.groupBox41.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.grp_IO_Conv_Stepper_2.SuspendLayout();
            this.grp_IO_Conv_Stepper_1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageCylinder.SuspendLayout();
            this.tabPageVacuum.SuspendLayout();
            this.tabPageRobot.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpRoboConn.SuspendLayout();
            this.tabPageCamera.SuspendLayout();
            this.grpCCDConn.SuspendLayout();
            this.tabPageLightControl.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPageScanner.SuspendLayout();
            this.grpScanner.SuspendLayout();
            this.tabPageSfcPdca.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Conveyor);
            this.tabControl1.Controls.Add(this.PickGantry);
            this.tabControl1.Controls.Add(this.ScrewGantry);
            this.tabControl1.Controls.Add(this.Feeder);
            this.tabControl1.Controls.Add(this.Shuttle);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1629, 936);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1428, 702);
            this.tabControl1.TabIndex = 4;
            // 
            // Conveyor
            // 
            this.Conveyor.BackColor = System.Drawing.Color.LightGray;
            this.Conveyor.Controls.Add(this.button25);
            this.Conveyor.Controls.Add(this.button23);
            this.Conveyor.Controls.Add(this.label1);
            this.Conveyor.Controls.Add(this.groupBox32);
            this.Conveyor.Controls.Add(this.groupBox37);
            this.Conveyor.Location = new System.Drawing.Point(4, 27);
            this.Conveyor.Name = "Conveyor";
            this.Conveyor.Size = new System.Drawing.Size(1420, 671);
            this.Conveyor.TabIndex = 2;
            this.Conveyor.Text = "CONVEYOR";
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(867, 170);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(159, 52);
            this.button25.TabIndex = 80;
            this.button25.Text = "Stop";
            this.button25.UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(453, 170);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(159, 52);
            this.button23.TabIndex = 79;
            this.button23.Text = "Con_Dryrun";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(625, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 25);
            this.label1.TabIndex = 78;
            this.label1.Text = "CONVEYOR STREAMLINE";
            // 
            // groupBox32
            // 
            this.groupBox32.BackColor = System.Drawing.Color.White;
            this.groupBox32.Controls.Add(this.comboBox11);
            this.groupBox32.Controls.Add(this.label162);
            this.groupBox32.Controls.Add(this.label163);
            this.groupBox32.Controls.Add(this.label164);
            this.groupBox32.Controls.Add(this.button33);
            this.groupBox32.Controls.Add(this.button34);
            this.groupBox32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox32.Location = new System.Drawing.Point(867, 289);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(267, 139);
            this.groupBox32.TabIndex = 12;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Streamline 2 (Working Conveyor)";
            // 
            // comboBox11
            // 
            this.comboBox11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Items.AddRange(new object[] {
            "Forward Direction",
            "Reverse Direction"});
            this.comboBox11.Location = new System.Drawing.Point(18, 112);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(139, 21);
            this.comboBox11.TabIndex = 5;
            this.comboBox11.Text = "Forward Direction";
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label162.Location = new System.Drawing.Point(211, 62);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(48, 14);
            this.label162.TabIndex = 4;
            this.label162.Text = "Status";
            // 
            // label163
            // 
            this.label163.BackColor = System.Drawing.Color.Green;
            this.label163.Location = new System.Drawing.Point(173, 53);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(30, 29);
            this.label163.TabIndex = 3;
            // 
            // label164
            // 
            this.label164.BackColor = System.Drawing.Color.Maroon;
            this.label164.Location = new System.Drawing.Point(173, 53);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(30, 29);
            this.label164.TabIndex = 2;
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button33.Font = new System.Drawing.Font("Cambria", 12F);
            this.button33.ForeColor = System.Drawing.Color.White;
            this.button33.Location = new System.Drawing.Point(18, 71);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(125, 29);
            this.button33.TabIndex = 1;
            this.button33.Text = "Stop";
            this.button33.UseVisualStyleBackColor = false;
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button34.Font = new System.Drawing.Font("Cambria", 12F);
            this.button34.ForeColor = System.Drawing.Color.White;
            this.button34.Location = new System.Drawing.Point(18, 29);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(125, 29);
            this.button34.TabIndex = 0;
            this.button34.Text = "Start";
            this.button34.UseVisualStyleBackColor = false;
            // 
            // groupBox37
            // 
            this.groupBox37.BackColor = System.Drawing.Color.White;
            this.groupBox37.Controls.Add(this.comboBox9);
            this.groupBox37.Controls.Add(this.label222);
            this.groupBox37.Controls.Add(this.label221);
            this.groupBox37.Controls.Add(this.label220);
            this.groupBox37.Controls.Add(this.button49);
            this.groupBox37.Controls.Add(this.Streamline1_Start);
            this.groupBox37.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox37.Location = new System.Drawing.Point(453, 289);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(267, 139);
            this.groupBox37.TabIndex = 11;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "Streamline 1 (Working Conveyor)";
            // 
            // comboBox9
            // 
            this.comboBox9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Items.AddRange(new object[] {
            "Forward Direction",
            "Reverse Direction"});
            this.comboBox9.Location = new System.Drawing.Point(21, 107);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(139, 21);
            this.comboBox9.TabIndex = 5;
            this.comboBox9.Text = "Forward Direction";
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label222.Location = new System.Drawing.Point(211, 68);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(48, 14);
            this.label222.TabIndex = 4;
            this.label222.Text = "Status";
            // 
            // label221
            // 
            this.label221.BackColor = System.Drawing.Color.Green;
            this.label221.Location = new System.Drawing.Point(173, 59);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(30, 29);
            this.label221.TabIndex = 3;
            // 
            // label220
            // 
            this.label220.BackColor = System.Drawing.Color.Maroon;
            this.label220.Location = new System.Drawing.Point(173, 59);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(30, 29);
            this.label220.TabIndex = 2;
            // 
            // button49
            // 
            this.button49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button49.Font = new System.Drawing.Font("Cambria", 12F);
            this.button49.ForeColor = System.Drawing.Color.White;
            this.button49.Location = new System.Drawing.Point(21, 69);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(125, 29);
            this.button49.TabIndex = 1;
            this.button49.Text = "Stop";
            this.button49.UseVisualStyleBackColor = false;
            // 
            // Streamline1_Start
            // 
            this.Streamline1_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Streamline1_Start.Font = new System.Drawing.Font("Cambria", 12F);
            this.Streamline1_Start.ForeColor = System.Drawing.Color.White;
            this.Streamline1_Start.Location = new System.Drawing.Point(21, 29);
            this.Streamline1_Start.Name = "Streamline1_Start";
            this.Streamline1_Start.Size = new System.Drawing.Size(125, 29);
            this.Streamline1_Start.TabIndex = 0;
            this.Streamline1_Start.Text = "Start";
            this.Streamline1_Start.UseVisualStyleBackColor = false;
            // 
            // PickGantry
            // 
            this.PickGantry.BackColor = System.Drawing.Color.LightGray;
            this.PickGantry.Controls.Add(this.AxisGroup);
            this.PickGantry.Controls.Add(this.AxisLabel);
            this.PickGantry.Controls.Add(this.AxisCombo);
            this.PickGantry.Controls.Add(this.button17);
            this.PickGantry.Controls.Add(this.DryCycle);
            this.PickGantry.Controls.Add(this.label6);
            this.PickGantry.Location = new System.Drawing.Point(4, 27);
            this.PickGantry.Name = "PickGantry";
            this.PickGantry.Padding = new System.Windows.Forms.Padding(3);
            this.PickGantry.Size = new System.Drawing.Size(1420, 671);
            this.PickGantry.TabIndex = 0;
            this.PickGantry.Text = "PICK GANTRY";
            // 
            // AxisGroup
            // 
            this.AxisGroup.Location = new System.Drawing.Point(82, 100);
            this.AxisGroup.Name = "AxisGroup";
            this.AxisGroup.Size = new System.Drawing.Size(1311, 502);
            this.AxisGroup.TabIndex = 83;
            this.AxisGroup.TabStop = false;
            // 
            // AxisLabel
            // 
            this.AxisLabel.BackColor = System.Drawing.Color.Transparent;
            this.AxisLabel.Location = new System.Drawing.Point(82, 70);
            this.AxisLabel.Name = "AxisLabel";
            this.AxisLabel.Size = new System.Drawing.Size(61, 16);
            this.AxisLabel.TabIndex = 82;
            this.AxisLabel.Text = "Axis";
            // 
            // AxisCombo
            // 
            this.AxisCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AxisCombo.FormattingEnabled = true;
            this.AxisCombo.Items.AddRange(new object[] {
            "X1 Axis",
            "Y1 Axis",
            "Z1 Axis"});
            this.AxisCombo.Location = new System.Drawing.Point(148, 68);
            this.AxisCombo.Name = "AxisCombo";
            this.AxisCombo.Size = new System.Drawing.Size(104, 26);
            this.AxisCombo.TabIndex = 81;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(1300, 61);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(84, 33);
            this.button17.TabIndex = 80;
            this.button17.Text = "Stop";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // DryCycle
            // 
            this.DryCycle.Location = new System.Drawing.Point(1170, 61);
            this.DryCycle.Name = "DryCycle";
            this.DryCycle.Size = new System.Drawing.Size(111, 33);
            this.DryCycle.TabIndex = 79;
            this.DryCycle.Text = "DryCycle";
            this.DryCycle.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(630, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 25);
            this.label6.TabIndex = 78;
            this.label6.Text = "PICK GANTRY";
            // 
            // ScrewGantry
            // 
            this.ScrewGantry.BackColor = System.Drawing.Color.LightGray;
            this.ScrewGantry.Controls.Add(this.button24);
            this.ScrewGantry.Controls.Add(this.button19);
            this.ScrewGantry.Controls.Add(this.button22);
            this.ScrewGantry.Controls.Add(this.button21);
            this.ScrewGantry.Controls.Add(this.label8);
            this.ScrewGantry.Controls.Add(this.Screw_Gantry);
            this.ScrewGantry.Location = new System.Drawing.Point(4, 27);
            this.ScrewGantry.Name = "ScrewGantry";
            this.ScrewGantry.Size = new System.Drawing.Size(1420, 671);
            this.ScrewGantry.TabIndex = 5;
            this.ScrewGantry.Text = "SCREW GANTRY";
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(600, 55);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(126, 28);
            this.button24.TabIndex = 82;
            this.button24.Text = "RStop";
            this.button24.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(789, 59);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(156, 33);
            this.button19.TabIndex = 80;
            this.button19.Text = "Robot_Dryrun";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(1083, 55);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(91, 28);
            this.button22.TabIndex = 79;
            this.button22.Text = "Stop";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(971, 55);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(105, 28);
            this.button21.TabIndex = 43;
            this.button21.Text = "DryCycle";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(723, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 25);
            this.label8.TabIndex = 78;
            this.label8.Text = "SCREW GANTRY";
            // 
            // Screw_Gantry
            // 
            this.Screw_Gantry.Controls.Add(this.AxisY1);
            this.Screw_Gantry.Controls.Add(this.AxisY2);
            this.Screw_Gantry.Controls.Add(this.AxisX1);
            this.Screw_Gantry.Controls.Add(this.AxisX2);
            this.Screw_Gantry.Controls.Add(this.AxisZ1);
            this.Screw_Gantry.Controls.Add(this.AxisZ2);
            this.Screw_Gantry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Screw_Gantry.Location = new System.Drawing.Point(3, 55);
            this.Screw_Gantry.Name = "Screw_Gantry";
            this.Screw_Gantry.SelectedIndex = 0;
            this.Screw_Gantry.Size = new System.Drawing.Size(1379, 575);
            this.Screw_Gantry.TabIndex = 76;
            // 
            // AxisY1
            // 
            this.AxisY1.BackColor = System.Drawing.Color.LightGray;
            this.AxisY1.Controls.Add(this.groupBox22);
            this.AxisY1.Location = new System.Drawing.Point(4, 29);
            this.AxisY1.Name = "AxisY1";
            this.AxisY1.Padding = new System.Windows.Forms.Padding(3);
            this.AxisY1.Size = new System.Drawing.Size(1371, 542);
            this.AxisY1.TabIndex = 0;
            this.AxisY1.Text = "Y1 - Axis";
            // 
            // groupBox22
            // 
            this.groupBox22.BackColor = System.Drawing.Color.White;
            this.groupBox22.Controls.Add(this.groupBox44);
            this.groupBox22.Controls.Add(this.groupBox45);
            this.groupBox22.Controls.Add(this.groupBox46);
            this.groupBox22.Controls.Add(this.groupBox47);
            this.groupBox22.Controls.Add(this.groupBox48);
            this.groupBox22.Controls.Add(this.groupBox49);
            this.groupBox22.Controls.Add(this.groupBox50);
            this.groupBox22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox22.Location = new System.Drawing.Point(68, 55);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(1116, 485);
            this.groupBox22.TabIndex = 39;
            this.groupBox22.TabStop = false;
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.Btn_ScrewServo_Enable_X1);
            this.groupBox44.Controls.Add(this.btnScrewServoX1ClearErr);
            this.groupBox44.Controls.Add(this.Btn_ScrewServo_disable_X1);
            this.groupBox44.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox44.Location = new System.Drawing.Point(49, 149);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(177, 168);
            this.groupBox44.TabIndex = 75;
            this.groupBox44.TabStop = false;
            this.groupBox44.Text = "Device Control";
            // 
            // Btn_ScrewServo_Enable_X1
            // 
            this.Btn_ScrewServo_Enable_X1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_Enable_X1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_Enable_X1.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_Enable_X1.Location = new System.Drawing.Point(11, 26);
            this.Btn_ScrewServo_Enable_X1.Name = "Btn_ScrewServo_Enable_X1";
            this.Btn_ScrewServo_Enable_X1.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_Enable_X1.TabIndex = 71;
            this.Btn_ScrewServo_Enable_X1.Text = "Servo Enable";
            this.Btn_ScrewServo_Enable_X1.UseVisualStyleBackColor = false;
            // 
            // btnScrewServoX1ClearErr
            // 
            this.btnScrewServoX1ClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewServoX1ClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewServoX1ClearErr.ForeColor = System.Drawing.Color.White;
            this.btnScrewServoX1ClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnScrewServoX1ClearErr.Name = "btnScrewServoX1ClearErr";
            this.btnScrewServoX1ClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnScrewServoX1ClearErr.TabIndex = 71;
            this.btnScrewServoX1ClearErr.Text = "Servo Clear Error";
            this.btnScrewServoX1ClearErr.UseVisualStyleBackColor = false;
            // 
            // Btn_ScrewServo_disable_X1
            // 
            this.Btn_ScrewServo_disable_X1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_disable_X1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_disable_X1.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_disable_X1.Location = new System.Drawing.Point(11, 70);
            this.Btn_ScrewServo_disable_X1.Name = "Btn_ScrewServo_disable_X1";
            this.Btn_ScrewServo_disable_X1.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_disable_X1.TabIndex = 71;
            this.Btn_ScrewServo_disable_X1.Text = "Servo Disable";
            this.Btn_ScrewServo_disable_X1.UseVisualStyleBackColor = false;
            // 
            // groupBox45
            // 
            this.groupBox45.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox45.Controls.Add(this.label24);
            this.groupBox45.Controls.Add(this.lbl_X1ScrewServo_ActualPosition);
            this.groupBox45.Controls.Add(this.label72);
            this.groupBox45.Controls.Add(this.label90);
            this.groupBox45.Controls.Add(this.label110);
            this.groupBox45.Controls.Add(this.Targetposition_Screw_X1);
            this.groupBox45.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox45.Location = new System.Drawing.Point(732, 14);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new System.Drawing.Size(363, 128);
            this.groupBox45.TabIndex = 74;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "Live Values";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(299, 86);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 14);
            this.label24.TabIndex = 73;
            this.label24.Text = "(mm)";
            // 
            // lbl_X1ScrewServo_ActualPosition
            // 
            this.lbl_X1ScrewServo_ActualPosition.AutoSize = true;
            this.lbl_X1ScrewServo_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_X1ScrewServo_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_X1ScrewServo_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_X1ScrewServo_ActualPosition.Location = new System.Drawing.Point(191, 42);
            this.lbl_X1ScrewServo_ActualPosition.Name = "lbl_X1ScrewServo_ActualPosition";
            this.lbl_X1ScrewServo_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_X1ScrewServo_ActualPosition.TabIndex = 53;
            this.lbl_X1ScrewServo_ActualPosition.Text = "0";
            this.lbl_X1ScrewServo_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(299, 45);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(37, 14);
            this.label72.TabIndex = 75;
            this.label72.Text = "(mm)";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(28, 46);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(139, 14);
            this.label90.TabIndex = 52;
            this.label90.Text = "Servo Actual Position";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label110.Location = new System.Drawing.Point(28, 83);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(140, 14);
            this.label110.TabIndex = 54;
            this.label110.Text = "Servo Target Position";
            // 
            // Targetposition_Screw_X1
            // 
            this.Targetposition_Screw_X1.AutoSize = true;
            this.Targetposition_Screw_X1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Targetposition_Screw_X1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Targetposition_Screw_X1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Targetposition_Screw_X1.Location = new System.Drawing.Point(191, 83);
            this.Targetposition_Screw_X1.Name = "Targetposition_Screw_X1";
            this.Targetposition_Screw_X1.Size = new System.Drawing.Size(18, 16);
            this.Targetposition_Screw_X1.TabIndex = 55;
            this.Targetposition_Screw_X1.Text = "0";
            this.Targetposition_Screw_X1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox46
            // 
            this.groupBox46.Controls.Add(this.button4);
            this.groupBox46.Controls.Add(this.button5);
            this.groupBox46.Controls.Add(this.textBox15);
            this.groupBox46.Controls.Add(this.textBox16);
            this.groupBox46.Controls.Add(this.textBox17);
            this.groupBox46.Controls.Add(this.label144);
            this.groupBox46.Controls.Add(this.label145);
            this.groupBox46.Controls.Add(this.textBox18);
            this.groupBox46.Controls.Add(this.label152);
            this.groupBox46.Controls.Add(this.textBox21);
            this.groupBox46.Controls.Add(this.label154);
            this.groupBox46.Controls.Add(this.label155);
            this.groupBox46.Controls.Add(this.label160);
            this.groupBox46.Controls.Add(this.label161);
            this.groupBox46.Controls.Add(this.label165);
            this.groupBox46.Controls.Add(this.label178);
            this.groupBox46.Controls.Add(this.label183);
            this.groupBox46.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox46.Location = new System.Drawing.Point(155, 326);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new System.Drawing.Size(781, 149);
            this.groupBox46.TabIndex = 73;
            this.groupBox46.TabStop = false;
            this.groupBox46.Text = "Point To Point Control";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(399, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 38);
            this.button4.TabIndex = 71;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(203, 103);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 38);
            this.button5.TabIndex = 70;
            this.button5.Text = "Move";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(603, 28);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(67, 26);
            this.textBox15.TabIndex = 61;
            // 
            // textBox16
            // 
            this.textBox16.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(336, 65);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(67, 26);
            this.textBox16.TabIndex = 61;
            // 
            // textBox17
            // 
            this.textBox17.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(336, 28);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(67, 26);
            this.textBox17.TabIndex = 61;
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.Location = new System.Drawing.Point(21, 80);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(84, 14);
            this.label144.TabIndex = 37;
            this.label144.Text = "End Position";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.Location = new System.Drawing.Point(14, 40);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(93, 14);
            this.label145.TabIndex = 37;
            this.label145.Text = "Start Position";
            // 
            // textBox18
            // 
            this.textBox18.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.Location = new System.Drawing.Point(105, 71);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(67, 26);
            this.textBox18.TabIndex = 59;
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label152.Location = new System.Drawing.Point(539, 40);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(62, 14);
            this.label152.TabIndex = 60;
            this.label152.Text = "Iteration";
            // 
            // textBox21
            // 
            this.textBox21.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(105, 32);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(67, 26);
            this.textBox21.TabIndex = 59;
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label154.Location = new System.Drawing.Point(297, 76);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(35, 14);
            this.label154.TabIndex = 60;
            this.label154.Text = "Wait";
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.Location = new System.Drawing.Point(179, 80);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(37, 14);
            this.label155.TabIndex = 66;
            this.label155.Text = "(mm)";
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label160.Location = new System.Drawing.Point(676, 40);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(39, 14);
            this.label160.TabIndex = 67;
            this.label160.Text = "count";
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label161.Location = new System.Drawing.Point(287, 40);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(45, 14);
            this.label161.TabIndex = 60;
            this.label161.Text = "Speed";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label165.Location = new System.Drawing.Point(410, 76);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(25, 14);
            this.label165.TabIndex = 67;
            this.label165.Text = "sec";
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label178.Location = new System.Drawing.Point(179, 40);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(37, 14);
            this.label178.TabIndex = 66;
            this.label178.Text = "(mm)";
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label183.Location = new System.Drawing.Point(410, 40);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(47, 14);
            this.label183.TabIndex = 67;
            this.label183.Text = "(mm/s)";
            // 
            // groupBox47
            // 
            this.groupBox47.BackColor = System.Drawing.Color.White;
            this.groupBox47.Controls.Add(this.comboBox1);
            this.groupBox47.Controls.Add(this.label184);
            this.groupBox47.Controls.Add(this.textBox23);
            this.groupBox47.Controls.Add(this.label185);
            this.groupBox47.Controls.Add(this.label186);
            this.groupBox47.Controls.Add(this.button6);
            this.groupBox47.Controls.Add(this.btnScrewJogAdd_X1);
            this.groupBox47.Controls.Add(this.label187);
            this.groupBox47.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox47.Location = new System.Drawing.Point(827, 149);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new System.Drawing.Size(234, 168);
            this.groupBox47.TabIndex = 72;
            this.groupBox47.TabStop = false;
            this.groupBox47.Text = "Jog Control";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox1.Location = new System.Drawing.Point(105, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(67, 26);
            this.comboBox1.TabIndex = 78;
            this.comboBox1.Visible = false;
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label184.Location = new System.Drawing.Point(176, 41);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(37, 14);
            this.label184.TabIndex = 77;
            this.label184.Text = "(mm)";
            this.label184.Visible = false;
            // 
            // textBox23
            // 
            this.textBox23.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox23.Location = new System.Drawing.Point(105, 32);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(67, 26);
            this.textBox23.TabIndex = 76;
            this.textBox23.Visible = false;
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label185.Location = new System.Drawing.Point(20, 40);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(83, 14);
            this.label185.TabIndex = 75;
            this.label185.Text = "Jog Position";
            this.label185.Visible = false;
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label186.Location = new System.Drawing.Point(172, 71);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(47, 14);
            this.label186.TabIndex = 73;
            this.label186.Text = "(mm/s)";
            this.label186.Visible = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(129, 107);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(83, 38);
            this.button6.TabIndex = 74;
            this.button6.Text = "Jog -";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // btnScrewJogAdd_X1
            // 
            this.btnScrewJogAdd_X1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewJogAdd_X1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewJogAdd_X1.ForeColor = System.Drawing.Color.White;
            this.btnScrewJogAdd_X1.Location = new System.Drawing.Point(24, 107);
            this.btnScrewJogAdd_X1.Name = "btnScrewJogAdd_X1";
            this.btnScrewJogAdd_X1.Size = new System.Drawing.Size(83, 38);
            this.btnScrewJogAdd_X1.TabIndex = 73;
            this.btnScrewJogAdd_X1.Text = "Jog +";
            this.btnScrewJogAdd_X1.UseVisualStyleBackColor = false;
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label187.Location = new System.Drawing.Point(20, 72);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(81, 14);
            this.label187.TabIndex = 37;
            this.label187.Text = "Jog Velocity";
            this.label187.Visible = false;
            // 
            // groupBox48
            // 
            this.groupBox48.BackColor = System.Drawing.Color.White;
            this.groupBox48.Controls.Add(this.btn_X1stop_home);
            this.groupBox48.Controls.Add(this.label194);
            this.groupBox48.Controls.Add(this.btnScrewHome_X1);
            this.groupBox48.Controls.Add(this.textBox24);
            this.groupBox48.Controls.Add(this.label195);
            this.groupBox48.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox48.Location = new System.Drawing.Point(539, 153);
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Size = new System.Drawing.Size(234, 165);
            this.groupBox48.TabIndex = 71;
            this.groupBox48.TabStop = false;
            this.groupBox48.Text = "Homing Control";
            // 
            // btn_X1stop_home
            // 
            this.btn_X1stop_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_X1stop_home.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_X1stop_home.ForeColor = System.Drawing.Color.White;
            this.btn_X1stop_home.Location = new System.Drawing.Point(126, 105);
            this.btn_X1stop_home.Name = "btn_X1stop_home";
            this.btn_X1stop_home.Size = new System.Drawing.Size(83, 38);
            this.btn_X1stop_home.TabIndex = 72;
            this.btn_X1stop_home.Text = "Stop";
            this.btn_X1stop_home.UseVisualStyleBackColor = false;
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label194.Location = new System.Drawing.Point(179, 55);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(47, 14);
            this.label194.TabIndex = 72;
            this.label194.Text = "(mm/s)";
            // 
            // btnScrewHome_X1
            // 
            this.btnScrewHome_X1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewHome_X1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewHome_X1.ForeColor = System.Drawing.Color.White;
            this.btnScrewHome_X1.Location = new System.Drawing.Point(23, 105);
            this.btnScrewHome_X1.Name = "btnScrewHome_X1";
            this.btnScrewHome_X1.Size = new System.Drawing.Size(83, 38);
            this.btnScrewHome_X1.TabIndex = 72;
            this.btnScrewHome_X1.Text = "Home";
            this.btnScrewHome_X1.UseVisualStyleBackColor = false;
            // 
            // textBox24
            // 
            this.textBox24.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox24.Location = new System.Drawing.Point(108, 47);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(67, 26);
            this.textBox24.TabIndex = 59;
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label195.Location = new System.Drawing.Point(9, 55);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(94, 14);
            this.label195.TabIndex = 37;
            this.label195.Text = "Home Velocity";
            // 
            // groupBox49
            // 
            this.groupBox49.BackColor = System.Drawing.Color.White;
            this.groupBox49.Controls.Add(this.btn_x1ScrewMove_stop);
            this.groupBox49.Controls.Add(this.btnScrewSVMove_X1);
            this.groupBox49.Controls.Add(this.label196);
            this.groupBox49.Controls.Add(this.label197);
            this.groupBox49.Controls.Add(this.lbl_X1ScrewSV_Speed);
            this.groupBox49.Controls.Add(this.label198);
            this.groupBox49.Controls.Add(this.lbl_X1ScrewSV_TargetPosition);
            this.groupBox49.Controls.Add(this.label199);
            this.groupBox49.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox49.Location = new System.Drawing.Point(275, 149);
            this.groupBox49.Name = "groupBox49";
            this.groupBox49.Size = new System.Drawing.Size(223, 168);
            this.groupBox49.TabIndex = 56;
            this.groupBox49.TabStop = false;
            this.groupBox49.Text = "Motion Control";
            // 
            // btn_x1ScrewMove_stop
            // 
            this.btn_x1ScrewMove_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_x1ScrewMove_stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_x1ScrewMove_stop.ForeColor = System.Drawing.Color.White;
            this.btn_x1ScrewMove_stop.Location = new System.Drawing.Point(117, 107);
            this.btn_x1ScrewMove_stop.Name = "btn_x1ScrewMove_stop";
            this.btn_x1ScrewMove_stop.Size = new System.Drawing.Size(83, 38);
            this.btn_x1ScrewMove_stop.TabIndex = 72;
            this.btn_x1ScrewMove_stop.Text = "Stop";
            this.btn_x1ScrewMove_stop.UseVisualStyleBackColor = false;
            // 
            // btnScrewSVMove_X1
            // 
            this.btnScrewSVMove_X1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewSVMove_X1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewSVMove_X1.ForeColor = System.Drawing.Color.White;
            this.btnScrewSVMove_X1.Location = new System.Drawing.Point(21, 107);
            this.btnScrewSVMove_X1.Name = "btnScrewSVMove_X1";
            this.btnScrewSVMove_X1.Size = new System.Drawing.Size(83, 38);
            this.btnScrewSVMove_X1.TabIndex = 70;
            this.btnScrewSVMove_X1.Text = "Move";
            this.btnScrewSVMove_X1.UseVisualStyleBackColor = false;
            // 
            // label196
            // 
            this.label196.AutoSize = true;
            this.label196.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label196.Location = new System.Drawing.Point(158, 79);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(47, 14);
            this.label196.TabIndex = 67;
            this.label196.Text = "(mm/s)";
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label197.Location = new System.Drawing.Point(158, 37);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(37, 14);
            this.label197.TabIndex = 66;
            this.label197.Text = "(mm)";
            // 
            // lbl_X1ScrewSV_Speed
            // 
            this.lbl_X1ScrewSV_Speed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_X1ScrewSV_Speed.Location = new System.Drawing.Point(84, 66);
            this.lbl_X1ScrewSV_Speed.Name = "lbl_X1ScrewSV_Speed";
            this.lbl_X1ScrewSV_Speed.Size = new System.Drawing.Size(67, 26);
            this.lbl_X1ScrewSV_Speed.TabIndex = 61;
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label198.Location = new System.Drawing.Point(22, 73);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(45, 14);
            this.label198.TabIndex = 60;
            this.label198.Text = "Speed";
            // 
            // lbl_X1ScrewSV_TargetPosition
            // 
            this.lbl_X1ScrewSV_TargetPosition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_X1ScrewSV_TargetPosition.Location = new System.Drawing.Point(84, 29);
            this.lbl_X1ScrewSV_TargetPosition.Name = "lbl_X1ScrewSV_TargetPosition";
            this.lbl_X1ScrewSV_TargetPosition.Size = new System.Drawing.Size(67, 26);
            this.lbl_X1ScrewSV_TargetPosition.TabIndex = 59;
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label199.Location = new System.Drawing.Point(22, 36);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(57, 14);
            this.label199.TabIndex = 37;
            this.label199.Text = "Position";
            // 
            // groupBox50
            // 
            this.groupBox50.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox50.Controls.Add(this.lblScrewServoX1disable);
            this.groupBox50.Controls.Add(this.label201);
            this.groupBox50.Controls.Add(this.lblScrewServoX1Error);
            this.groupBox50.Controls.Add(this.label203);
            this.groupBox50.Controls.Add(this.lblScrewServoX1Positive_limit);
            this.groupBox50.Controls.Add(this.label205);
            this.groupBox50.Controls.Add(this.lblScrewServoX1Home);
            this.groupBox50.Controls.Add(this.lblScrewServoX1Running);
            this.groupBox50.Controls.Add(this.lblScrewServoX1Ready);
            this.groupBox50.Controls.Add(this.lblScrewServoX1Negative_limit);
            this.groupBox50.Controls.Add(this.lblScrewServoX1Enable);
            this.groupBox50.Controls.Add(this.label211);
            this.groupBox50.Controls.Add(this.label212);
            this.groupBox50.Controls.Add(this.label213);
            this.groupBox50.Controls.Add(this.label214);
            this.groupBox50.Controls.Add(this.label215);
            this.groupBox50.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox50.Location = new System.Drawing.Point(15, 14);
            this.groupBox50.Name = "groupBox50";
            this.groupBox50.Size = new System.Drawing.Size(699, 128);
            this.groupBox50.TabIndex = 37;
            this.groupBox50.TabStop = false;
            this.groupBox50.Text = "Device Status";
            // 
            // lblScrewServoX1disable
            // 
            this.lblScrewServoX1disable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX1disable.Location = new System.Drawing.Point(105, 90);
            this.lblScrewServoX1disable.Name = "lblScrewServoX1disable";
            this.lblScrewServoX1disable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX1disable.TabIndex = 63;
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label201.Location = new System.Drawing.Point(14, 98);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(89, 14);
            this.label201.TabIndex = 62;
            this.label201.Text = "Servo Disable";
            // 
            // lblScrewServoX1Error
            // 
            this.lblScrewServoX1Error.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX1Error.Location = new System.Drawing.Point(461, 87);
            this.lblScrewServoX1Error.Name = "lblScrewServoX1Error";
            this.lblScrewServoX1Error.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX1Error.TabIndex = 61;
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label203.Location = new System.Drawing.Point(367, 94);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(93, 14);
            this.label203.TabIndex = 60;
            this.label203.Text = "Servo In Error";
            // 
            // lblScrewServoX1Positive_limit
            // 
            this.lblScrewServoX1Positive_limit.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX1Positive_limit.Location = new System.Drawing.Point(655, 87);
            this.lblScrewServoX1Positive_limit.Name = "lblScrewServoX1Positive_limit";
            this.lblScrewServoX1Positive_limit.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX1Positive_limit.TabIndex = 59;
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label205.Location = new System.Drawing.Point(561, 94);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(89, 14);
            this.label205.TabIndex = 56;
            this.label205.Text = "Positive Limit";
            // 
            // lblScrewServoX1Home
            // 
            this.lblScrewServoX1Home.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX1Home.Location = new System.Drawing.Point(461, 36);
            this.lblScrewServoX1Home.Name = "lblScrewServoX1Home";
            this.lblScrewServoX1Home.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX1Home.TabIndex = 48;
            // 
            // lblScrewServoX1Running
            // 
            this.lblScrewServoX1Running.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX1Running.Location = new System.Drawing.Point(285, 87);
            this.lblScrewServoX1Running.Name = "lblScrewServoX1Running";
            this.lblScrewServoX1Running.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX1Running.TabIndex = 47;
            // 
            // lblScrewServoX1Ready
            // 
            this.lblScrewServoX1Ready.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX1Ready.Location = new System.Drawing.Point(285, 33);
            this.lblScrewServoX1Ready.Name = "lblScrewServoX1Ready";
            this.lblScrewServoX1Ready.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX1Ready.TabIndex = 46;
            // 
            // lblScrewServoX1Negative_limit
            // 
            this.lblScrewServoX1Negative_limit.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX1Negative_limit.Location = new System.Drawing.Point(655, 33);
            this.lblScrewServoX1Negative_limit.Name = "lblScrewServoX1Negative_limit";
            this.lblScrewServoX1Negative_limit.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX1Negative_limit.TabIndex = 45;
            // 
            // lblScrewServoX1Enable
            // 
            this.lblScrewServoX1Enable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX1Enable.Location = new System.Drawing.Point(105, 33);
            this.lblScrewServoX1Enable.Name = "lblScrewServoX1Enable";
            this.lblScrewServoX1Enable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX1Enable.TabIndex = 45;
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label211.Location = new System.Drawing.Point(187, 94);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(98, 14);
            this.label211.TabIndex = 43;
            this.label211.Text = "Servo Running";
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label212.Location = new System.Drawing.Point(379, 44);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(81, 14);
            this.label212.TabIndex = 41;
            this.label212.Text = "Servo Home";
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label213.Location = new System.Drawing.Point(556, 41);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(94, 14);
            this.label213.TabIndex = 37;
            this.label213.Text = "Negative Limit";
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label214.Location = new System.Drawing.Point(201, 41);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(84, 14);
            this.label214.TabIndex = 39;
            this.label214.Text = "Servo Ready";
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label215.Location = new System.Drawing.Point(15, 41);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(86, 14);
            this.label215.TabIndex = 37;
            this.label215.Text = "Servo Enable";
            // 
            // AxisY2
            // 
            this.AxisY2.BackColor = System.Drawing.Color.LightGray;
            this.AxisY2.Controls.Add(this.groupBox94);
            this.AxisY2.Location = new System.Drawing.Point(4, 29);
            this.AxisY2.Name = "AxisY2";
            this.AxisY2.Size = new System.Drawing.Size(1371, 542);
            this.AxisY2.TabIndex = 3;
            this.AxisY2.Text = "Y2 - Axis";
            // 
            // groupBox94
            // 
            this.groupBox94.BackColor = System.Drawing.Color.White;
            this.groupBox94.Controls.Add(this.groupBox95);
            this.groupBox94.Controls.Add(this.groupBox96);
            this.groupBox94.Controls.Add(this.groupBox97);
            this.groupBox94.Controls.Add(this.groupBox98);
            this.groupBox94.Controls.Add(this.groupBox99);
            this.groupBox94.Controls.Add(this.groupBox100);
            this.groupBox94.Controls.Add(this.groupBox101);
            this.groupBox94.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox94.Location = new System.Drawing.Point(239, 47);
            this.groupBox94.Name = "groupBox94";
            this.groupBox94.Size = new System.Drawing.Size(1116, 485);
            this.groupBox94.TabIndex = 40;
            this.groupBox94.TabStop = false;
            // 
            // groupBox95
            // 
            this.groupBox95.Controls.Add(this.Btn_ScrewServo_Enable_X2);
            this.groupBox95.Controls.Add(this.btnScrewServoX2ClearErr);
            this.groupBox95.Controls.Add(this.Btn_ScrewServo_disable_X2);
            this.groupBox95.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox95.Location = new System.Drawing.Point(49, 149);
            this.groupBox95.Name = "groupBox95";
            this.groupBox95.Size = new System.Drawing.Size(177, 168);
            this.groupBox95.TabIndex = 75;
            this.groupBox95.TabStop = false;
            this.groupBox95.Text = "Device Control";
            // 
            // Btn_ScrewServo_Enable_X2
            // 
            this.Btn_ScrewServo_Enable_X2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_Enable_X2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_Enable_X2.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_Enable_X2.Location = new System.Drawing.Point(11, 26);
            this.Btn_ScrewServo_Enable_X2.Name = "Btn_ScrewServo_Enable_X2";
            this.Btn_ScrewServo_Enable_X2.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_Enable_X2.TabIndex = 71;
            this.Btn_ScrewServo_Enable_X2.Text = "Servo Enable";
            this.Btn_ScrewServo_Enable_X2.UseVisualStyleBackColor = false;
            // 
            // btnScrewServoX2ClearErr
            // 
            this.btnScrewServoX2ClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewServoX2ClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewServoX2ClearErr.ForeColor = System.Drawing.Color.White;
            this.btnScrewServoX2ClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnScrewServoX2ClearErr.Name = "btnScrewServoX2ClearErr";
            this.btnScrewServoX2ClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnScrewServoX2ClearErr.TabIndex = 71;
            this.btnScrewServoX2ClearErr.Text = "Servo Clear Error";
            this.btnScrewServoX2ClearErr.UseVisualStyleBackColor = false;
            // 
            // Btn_ScrewServo_disable_X2
            // 
            this.Btn_ScrewServo_disable_X2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_disable_X2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_disable_X2.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_disable_X2.Location = new System.Drawing.Point(11, 70);
            this.Btn_ScrewServo_disable_X2.Name = "Btn_ScrewServo_disable_X2";
            this.Btn_ScrewServo_disable_X2.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_disable_X2.TabIndex = 71;
            this.Btn_ScrewServo_disable_X2.Text = "Servo Disable";
            this.Btn_ScrewServo_disable_X2.UseVisualStyleBackColor = false;
            // 
            // groupBox96
            // 
            this.groupBox96.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox96.Controls.Add(this.label396);
            this.groupBox96.Controls.Add(this.lbl_X2ScrewServo_ActualPosition);
            this.groupBox96.Controls.Add(this.label400);
            this.groupBox96.Controls.Add(this.label401);
            this.groupBox96.Controls.Add(this.label402);
            this.groupBox96.Controls.Add(this.Targetposition_Screw_X2);
            this.groupBox96.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox96.Location = new System.Drawing.Point(732, 14);
            this.groupBox96.Name = "groupBox96";
            this.groupBox96.Size = new System.Drawing.Size(363, 128);
            this.groupBox96.TabIndex = 74;
            this.groupBox96.TabStop = false;
            this.groupBox96.Text = "Live Values";
            // 
            // label396
            // 
            this.label396.AutoSize = true;
            this.label396.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label396.Location = new System.Drawing.Point(299, 86);
            this.label396.Name = "label396";
            this.label396.Size = new System.Drawing.Size(37, 14);
            this.label396.TabIndex = 73;
            this.label396.Text = "(mm)";
            // 
            // lbl_X2ScrewServo_ActualPosition
            // 
            this.lbl_X2ScrewServo_ActualPosition.AutoSize = true;
            this.lbl_X2ScrewServo_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_X2ScrewServo_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_X2ScrewServo_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_X2ScrewServo_ActualPosition.Location = new System.Drawing.Point(191, 42);
            this.lbl_X2ScrewServo_ActualPosition.Name = "lbl_X2ScrewServo_ActualPosition";
            this.lbl_X2ScrewServo_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_X2ScrewServo_ActualPosition.TabIndex = 53;
            this.lbl_X2ScrewServo_ActualPosition.Text = "0";
            this.lbl_X2ScrewServo_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label400
            // 
            this.label400.AutoSize = true;
            this.label400.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label400.Location = new System.Drawing.Point(299, 45);
            this.label400.Name = "label400";
            this.label400.Size = new System.Drawing.Size(37, 14);
            this.label400.TabIndex = 75;
            this.label400.Text = "(mm)";
            // 
            // label401
            // 
            this.label401.AutoSize = true;
            this.label401.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label401.Location = new System.Drawing.Point(28, 46);
            this.label401.Name = "label401";
            this.label401.Size = new System.Drawing.Size(139, 14);
            this.label401.TabIndex = 52;
            this.label401.Text = "Servo Actual Position";
            // 
            // label402
            // 
            this.label402.AutoSize = true;
            this.label402.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label402.Location = new System.Drawing.Point(28, 83);
            this.label402.Name = "label402";
            this.label402.Size = new System.Drawing.Size(140, 14);
            this.label402.TabIndex = 54;
            this.label402.Text = "Servo Target Position";
            // 
            // Targetposition_Screw_X2
            // 
            this.Targetposition_Screw_X2.AutoSize = true;
            this.Targetposition_Screw_X2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Targetposition_Screw_X2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Targetposition_Screw_X2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Targetposition_Screw_X2.Location = new System.Drawing.Point(191, 83);
            this.Targetposition_Screw_X2.Name = "Targetposition_Screw_X2";
            this.Targetposition_Screw_X2.Size = new System.Drawing.Size(18, 16);
            this.Targetposition_Screw_X2.TabIndex = 55;
            this.Targetposition_Screw_X2.Text = "0";
            this.Targetposition_Screw_X2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox97
            // 
            this.groupBox97.Controls.Add(this.button85);
            this.groupBox97.Controls.Add(this.button86);
            this.groupBox97.Controls.Add(this.textBox70);
            this.groupBox97.Controls.Add(this.textBox71);
            this.groupBox97.Controls.Add(this.textBox72);
            this.groupBox97.Controls.Add(this.label404);
            this.groupBox97.Controls.Add(this.label405);
            this.groupBox97.Controls.Add(this.textBox73);
            this.groupBox97.Controls.Add(this.label406);
            this.groupBox97.Controls.Add(this.textBox74);
            this.groupBox97.Controls.Add(this.label407);
            this.groupBox97.Controls.Add(this.label412);
            this.groupBox97.Controls.Add(this.label413);
            this.groupBox97.Controls.Add(this.label414);
            this.groupBox97.Controls.Add(this.label415);
            this.groupBox97.Controls.Add(this.label416);
            this.groupBox97.Controls.Add(this.label417);
            this.groupBox97.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox97.Location = new System.Drawing.Point(155, 326);
            this.groupBox97.Name = "groupBox97";
            this.groupBox97.Size = new System.Drawing.Size(781, 149);
            this.groupBox97.TabIndex = 73;
            this.groupBox97.TabStop = false;
            this.groupBox97.Text = "Point To Point Control";
            // 
            // button85
            // 
            this.button85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button85.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button85.ForeColor = System.Drawing.Color.White;
            this.button85.Location = new System.Drawing.Point(399, 103);
            this.button85.Name = "button85";
            this.button85.Size = new System.Drawing.Size(83, 38);
            this.button85.TabIndex = 71;
            this.button85.Text = "Stop";
            this.button85.UseVisualStyleBackColor = false;
            // 
            // button86
            // 
            this.button86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button86.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button86.ForeColor = System.Drawing.Color.White;
            this.button86.Location = new System.Drawing.Point(203, 103);
            this.button86.Name = "button86";
            this.button86.Size = new System.Drawing.Size(83, 38);
            this.button86.TabIndex = 70;
            this.button86.Text = "Move";
            this.button86.UseVisualStyleBackColor = false;
            // 
            // textBox70
            // 
            this.textBox70.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox70.Location = new System.Drawing.Point(603, 28);
            this.textBox70.Name = "textBox70";
            this.textBox70.Size = new System.Drawing.Size(67, 26);
            this.textBox70.TabIndex = 61;
            // 
            // textBox71
            // 
            this.textBox71.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox71.Location = new System.Drawing.Point(336, 65);
            this.textBox71.Name = "textBox71";
            this.textBox71.Size = new System.Drawing.Size(67, 26);
            this.textBox71.TabIndex = 61;
            // 
            // textBox72
            // 
            this.textBox72.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox72.Location = new System.Drawing.Point(336, 28);
            this.textBox72.Name = "textBox72";
            this.textBox72.Size = new System.Drawing.Size(67, 26);
            this.textBox72.TabIndex = 61;
            // 
            // label404
            // 
            this.label404.AutoSize = true;
            this.label404.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label404.Location = new System.Drawing.Point(21, 80);
            this.label404.Name = "label404";
            this.label404.Size = new System.Drawing.Size(84, 14);
            this.label404.TabIndex = 37;
            this.label404.Text = "End Position";
            // 
            // label405
            // 
            this.label405.AutoSize = true;
            this.label405.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label405.Location = new System.Drawing.Point(14, 40);
            this.label405.Name = "label405";
            this.label405.Size = new System.Drawing.Size(93, 14);
            this.label405.TabIndex = 37;
            this.label405.Text = "Start Position";
            // 
            // textBox73
            // 
            this.textBox73.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox73.Location = new System.Drawing.Point(105, 71);
            this.textBox73.Name = "textBox73";
            this.textBox73.Size = new System.Drawing.Size(67, 26);
            this.textBox73.TabIndex = 59;
            // 
            // label406
            // 
            this.label406.AutoSize = true;
            this.label406.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label406.Location = new System.Drawing.Point(539, 40);
            this.label406.Name = "label406";
            this.label406.Size = new System.Drawing.Size(62, 14);
            this.label406.TabIndex = 60;
            this.label406.Text = "Iteration";
            // 
            // textBox74
            // 
            this.textBox74.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox74.Location = new System.Drawing.Point(105, 32);
            this.textBox74.Name = "textBox74";
            this.textBox74.Size = new System.Drawing.Size(67, 26);
            this.textBox74.TabIndex = 59;
            // 
            // label407
            // 
            this.label407.AutoSize = true;
            this.label407.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label407.Location = new System.Drawing.Point(297, 76);
            this.label407.Name = "label407";
            this.label407.Size = new System.Drawing.Size(35, 14);
            this.label407.TabIndex = 60;
            this.label407.Text = "Wait";
            // 
            // label412
            // 
            this.label412.AutoSize = true;
            this.label412.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label412.Location = new System.Drawing.Point(179, 80);
            this.label412.Name = "label412";
            this.label412.Size = new System.Drawing.Size(37, 14);
            this.label412.TabIndex = 66;
            this.label412.Text = "(mm)";
            // 
            // label413
            // 
            this.label413.AutoSize = true;
            this.label413.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label413.Location = new System.Drawing.Point(676, 40);
            this.label413.Name = "label413";
            this.label413.Size = new System.Drawing.Size(39, 14);
            this.label413.TabIndex = 67;
            this.label413.Text = "count";
            // 
            // label414
            // 
            this.label414.AutoSize = true;
            this.label414.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label414.Location = new System.Drawing.Point(287, 40);
            this.label414.Name = "label414";
            this.label414.Size = new System.Drawing.Size(45, 14);
            this.label414.TabIndex = 60;
            this.label414.Text = "Speed";
            // 
            // label415
            // 
            this.label415.AutoSize = true;
            this.label415.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label415.Location = new System.Drawing.Point(410, 76);
            this.label415.Name = "label415";
            this.label415.Size = new System.Drawing.Size(25, 14);
            this.label415.TabIndex = 67;
            this.label415.Text = "sec";
            // 
            // label416
            // 
            this.label416.AutoSize = true;
            this.label416.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label416.Location = new System.Drawing.Point(179, 40);
            this.label416.Name = "label416";
            this.label416.Size = new System.Drawing.Size(37, 14);
            this.label416.TabIndex = 66;
            this.label416.Text = "(mm)";
            // 
            // label417
            // 
            this.label417.AutoSize = true;
            this.label417.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label417.Location = new System.Drawing.Point(410, 40);
            this.label417.Name = "label417";
            this.label417.Size = new System.Drawing.Size(47, 14);
            this.label417.TabIndex = 67;
            this.label417.Text = "(mm/s)";
            // 
            // groupBox98
            // 
            this.groupBox98.BackColor = System.Drawing.Color.White;
            this.groupBox98.Controls.Add(this.comboBox7);
            this.groupBox98.Controls.Add(this.label418);
            this.groupBox98.Controls.Add(this.textBox75);
            this.groupBox98.Controls.Add(this.label419);
            this.groupBox98.Controls.Add(this.label420);
            this.groupBox98.Controls.Add(this.button87);
            this.groupBox98.Controls.Add(this.button88);
            this.groupBox98.Controls.Add(this.label421);
            this.groupBox98.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox98.Location = new System.Drawing.Point(827, 149);
            this.groupBox98.Name = "groupBox98";
            this.groupBox98.Size = new System.Drawing.Size(234, 168);
            this.groupBox98.TabIndex = 72;
            this.groupBox98.TabStop = false;
            this.groupBox98.Text = "Jog Control";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox7.Location = new System.Drawing.Point(105, 64);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(67, 26);
            this.comboBox7.TabIndex = 78;
            this.comboBox7.Visible = false;
            // 
            // label418
            // 
            this.label418.AutoSize = true;
            this.label418.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label418.Location = new System.Drawing.Point(176, 41);
            this.label418.Name = "label418";
            this.label418.Size = new System.Drawing.Size(37, 14);
            this.label418.TabIndex = 77;
            this.label418.Text = "(mm)";
            this.label418.Visible = false;
            // 
            // textBox75
            // 
            this.textBox75.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox75.Location = new System.Drawing.Point(105, 32);
            this.textBox75.Name = "textBox75";
            this.textBox75.Size = new System.Drawing.Size(67, 26);
            this.textBox75.TabIndex = 76;
            this.textBox75.Visible = false;
            // 
            // label419
            // 
            this.label419.AutoSize = true;
            this.label419.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label419.Location = new System.Drawing.Point(20, 40);
            this.label419.Name = "label419";
            this.label419.Size = new System.Drawing.Size(83, 14);
            this.label419.TabIndex = 75;
            this.label419.Text = "Jog Position";
            this.label419.Visible = false;
            // 
            // label420
            // 
            this.label420.AutoSize = true;
            this.label420.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label420.Location = new System.Drawing.Point(172, 71);
            this.label420.Name = "label420";
            this.label420.Size = new System.Drawing.Size(47, 14);
            this.label420.TabIndex = 73;
            this.label420.Text = "(mm/s)";
            this.label420.Visible = false;
            // 
            // button87
            // 
            this.button87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button87.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button87.ForeColor = System.Drawing.Color.White;
            this.button87.Location = new System.Drawing.Point(129, 107);
            this.button87.Name = "button87";
            this.button87.Size = new System.Drawing.Size(83, 38);
            this.button87.TabIndex = 74;
            this.button87.Text = "Jog -";
            this.button87.UseVisualStyleBackColor = false;
            // 
            // button88
            // 
            this.button88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button88.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button88.ForeColor = System.Drawing.Color.White;
            this.button88.Location = new System.Drawing.Point(24, 107);
            this.button88.Name = "button88";
            this.button88.Size = new System.Drawing.Size(83, 38);
            this.button88.TabIndex = 73;
            this.button88.Text = "Jog +";
            this.button88.UseVisualStyleBackColor = false;
            // 
            // label421
            // 
            this.label421.AutoSize = true;
            this.label421.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label421.Location = new System.Drawing.Point(20, 72);
            this.label421.Name = "label421";
            this.label421.Size = new System.Drawing.Size(81, 14);
            this.label421.TabIndex = 37;
            this.label421.Text = "Jog Velocity";
            this.label421.Visible = false;
            // 
            // groupBox99
            // 
            this.groupBox99.BackColor = System.Drawing.Color.White;
            this.groupBox99.Controls.Add(this.btn_X2stop_home);
            this.groupBox99.Controls.Add(this.label422);
            this.groupBox99.Controls.Add(this.btnScrewHome_X2);
            this.groupBox99.Controls.Add(this.textBox76);
            this.groupBox99.Controls.Add(this.label488);
            this.groupBox99.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox99.Location = new System.Drawing.Point(539, 153);
            this.groupBox99.Name = "groupBox99";
            this.groupBox99.Size = new System.Drawing.Size(234, 165);
            this.groupBox99.TabIndex = 71;
            this.groupBox99.TabStop = false;
            this.groupBox99.Text = "Homing Control";
            // 
            // btn_X2stop_home
            // 
            this.btn_X2stop_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_X2stop_home.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_X2stop_home.ForeColor = System.Drawing.Color.White;
            this.btn_X2stop_home.Location = new System.Drawing.Point(126, 105);
            this.btn_X2stop_home.Name = "btn_X2stop_home";
            this.btn_X2stop_home.Size = new System.Drawing.Size(83, 38);
            this.btn_X2stop_home.TabIndex = 72;
            this.btn_X2stop_home.Text = "Stop";
            this.btn_X2stop_home.UseVisualStyleBackColor = false;
            // 
            // label422
            // 
            this.label422.AutoSize = true;
            this.label422.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label422.Location = new System.Drawing.Point(179, 55);
            this.label422.Name = "label422";
            this.label422.Size = new System.Drawing.Size(47, 14);
            this.label422.TabIndex = 72;
            this.label422.Text = "(mm/s)";
            // 
            // btnScrewHome_X2
            // 
            this.btnScrewHome_X2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewHome_X2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewHome_X2.ForeColor = System.Drawing.Color.White;
            this.btnScrewHome_X2.Location = new System.Drawing.Point(23, 105);
            this.btnScrewHome_X2.Name = "btnScrewHome_X2";
            this.btnScrewHome_X2.Size = new System.Drawing.Size(83, 38);
            this.btnScrewHome_X2.TabIndex = 72;
            this.btnScrewHome_X2.Text = "Home";
            this.btnScrewHome_X2.UseVisualStyleBackColor = false;
            // 
            // textBox76
            // 
            this.textBox76.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox76.Location = new System.Drawing.Point(108, 47);
            this.textBox76.Name = "textBox76";
            this.textBox76.Size = new System.Drawing.Size(67, 26);
            this.textBox76.TabIndex = 59;
            // 
            // label488
            // 
            this.label488.AutoSize = true;
            this.label488.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label488.Location = new System.Drawing.Point(9, 55);
            this.label488.Name = "label488";
            this.label488.Size = new System.Drawing.Size(94, 14);
            this.label488.TabIndex = 37;
            this.label488.Text = "Home Velocity";
            // 
            // groupBox100
            // 
            this.groupBox100.BackColor = System.Drawing.Color.White;
            this.groupBox100.Controls.Add(this.btn_x2ScrewMove_stop);
            this.groupBox100.Controls.Add(this.btnScrewSVMove_X2);
            this.groupBox100.Controls.Add(this.label489);
            this.groupBox100.Controls.Add(this.label490);
            this.groupBox100.Controls.Add(this.lbl_X2ScrewSV_Speed);
            this.groupBox100.Controls.Add(this.label491);
            this.groupBox100.Controls.Add(this.txt_targetposition_ScrewX2);
            this.groupBox100.Controls.Add(this.label492);
            this.groupBox100.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox100.Location = new System.Drawing.Point(275, 149);
            this.groupBox100.Name = "groupBox100";
            this.groupBox100.Size = new System.Drawing.Size(223, 168);
            this.groupBox100.TabIndex = 56;
            this.groupBox100.TabStop = false;
            this.groupBox100.Text = "Motion Control";
            // 
            // btn_x2ScrewMove_stop
            // 
            this.btn_x2ScrewMove_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_x2ScrewMove_stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_x2ScrewMove_stop.ForeColor = System.Drawing.Color.White;
            this.btn_x2ScrewMove_stop.Location = new System.Drawing.Point(117, 107);
            this.btn_x2ScrewMove_stop.Name = "btn_x2ScrewMove_stop";
            this.btn_x2ScrewMove_stop.Size = new System.Drawing.Size(83, 38);
            this.btn_x2ScrewMove_stop.TabIndex = 72;
            this.btn_x2ScrewMove_stop.Text = "Stop";
            this.btn_x2ScrewMove_stop.UseVisualStyleBackColor = false;
            // 
            // btnScrewSVMove_X2
            // 
            this.btnScrewSVMove_X2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewSVMove_X2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewSVMove_X2.ForeColor = System.Drawing.Color.White;
            this.btnScrewSVMove_X2.Location = new System.Drawing.Point(21, 107);
            this.btnScrewSVMove_X2.Name = "btnScrewSVMove_X2";
            this.btnScrewSVMove_X2.Size = new System.Drawing.Size(83, 38);
            this.btnScrewSVMove_X2.TabIndex = 70;
            this.btnScrewSVMove_X2.Text = "Move";
            this.btnScrewSVMove_X2.UseVisualStyleBackColor = false;
            // 
            // label489
            // 
            this.label489.AutoSize = true;
            this.label489.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label489.Location = new System.Drawing.Point(158, 79);
            this.label489.Name = "label489";
            this.label489.Size = new System.Drawing.Size(47, 14);
            this.label489.TabIndex = 67;
            this.label489.Text = "(mm/s)";
            // 
            // label490
            // 
            this.label490.AutoSize = true;
            this.label490.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label490.Location = new System.Drawing.Point(158, 37);
            this.label490.Name = "label490";
            this.label490.Size = new System.Drawing.Size(37, 14);
            this.label490.TabIndex = 66;
            this.label490.Text = "(mm)";
            // 
            // lbl_X2ScrewSV_Speed
            // 
            this.lbl_X2ScrewSV_Speed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_X2ScrewSV_Speed.Location = new System.Drawing.Point(84, 66);
            this.lbl_X2ScrewSV_Speed.Name = "lbl_X2ScrewSV_Speed";
            this.lbl_X2ScrewSV_Speed.Size = new System.Drawing.Size(67, 26);
            this.lbl_X2ScrewSV_Speed.TabIndex = 61;
            // 
            // label491
            // 
            this.label491.AutoSize = true;
            this.label491.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label491.Location = new System.Drawing.Point(22, 73);
            this.label491.Name = "label491";
            this.label491.Size = new System.Drawing.Size(45, 14);
            this.label491.TabIndex = 60;
            this.label491.Text = "Speed";
            // 
            // txt_targetposition_ScrewX2
            // 
            this.txt_targetposition_ScrewX2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_targetposition_ScrewX2.Location = new System.Drawing.Point(84, 29);
            this.txt_targetposition_ScrewX2.Name = "txt_targetposition_ScrewX2";
            this.txt_targetposition_ScrewX2.Size = new System.Drawing.Size(67, 26);
            this.txt_targetposition_ScrewX2.TabIndex = 59;
            // 
            // label492
            // 
            this.label492.AutoSize = true;
            this.label492.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label492.Location = new System.Drawing.Point(22, 36);
            this.label492.Name = "label492";
            this.label492.Size = new System.Drawing.Size(57, 14);
            this.label492.TabIndex = 37;
            this.label492.Text = "Position";
            // 
            // groupBox101
            // 
            this.groupBox101.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox101.Controls.Add(this.lblScrewServoX2disable);
            this.groupBox101.Controls.Add(this.label494);
            this.groupBox101.Controls.Add(this.lblScrewServoX2Error);
            this.groupBox101.Controls.Add(this.label496);
            this.groupBox101.Controls.Add(this.lblScrewServoX2Positive_limit);
            this.groupBox101.Controls.Add(this.label498);
            this.groupBox101.Controls.Add(this.lblScrewServoX2Home);
            this.groupBox101.Controls.Add(this.lblScrewServoX2Running);
            this.groupBox101.Controls.Add(this.lblScrewServoX2Ready);
            this.groupBox101.Controls.Add(this.lblScrewServoX2Negative_limit);
            this.groupBox101.Controls.Add(this.lblScrewServoX2Enable);
            this.groupBox101.Controls.Add(this.label504);
            this.groupBox101.Controls.Add(this.label505);
            this.groupBox101.Controls.Add(this.label506);
            this.groupBox101.Controls.Add(this.label507);
            this.groupBox101.Controls.Add(this.label508);
            this.groupBox101.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox101.Location = new System.Drawing.Point(15, 14);
            this.groupBox101.Name = "groupBox101";
            this.groupBox101.Size = new System.Drawing.Size(699, 128);
            this.groupBox101.TabIndex = 37;
            this.groupBox101.TabStop = false;
            this.groupBox101.Text = "Device Status";
            // 
            // lblScrewServoX2disable
            // 
            this.lblScrewServoX2disable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX2disable.Location = new System.Drawing.Point(105, 90);
            this.lblScrewServoX2disable.Name = "lblScrewServoX2disable";
            this.lblScrewServoX2disable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX2disable.TabIndex = 63;
            // 
            // label494
            // 
            this.label494.AutoSize = true;
            this.label494.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label494.Location = new System.Drawing.Point(14, 98);
            this.label494.Name = "label494";
            this.label494.Size = new System.Drawing.Size(89, 14);
            this.label494.TabIndex = 62;
            this.label494.Text = "Servo Disable";
            // 
            // lblScrewServoX2Error
            // 
            this.lblScrewServoX2Error.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX2Error.Location = new System.Drawing.Point(461, 87);
            this.lblScrewServoX2Error.Name = "lblScrewServoX2Error";
            this.lblScrewServoX2Error.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX2Error.TabIndex = 61;
            // 
            // label496
            // 
            this.label496.AutoSize = true;
            this.label496.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label496.Location = new System.Drawing.Point(367, 94);
            this.label496.Name = "label496";
            this.label496.Size = new System.Drawing.Size(93, 14);
            this.label496.TabIndex = 60;
            this.label496.Text = "Servo In Error";
            // 
            // lblScrewServoX2Positive_limit
            // 
            this.lblScrewServoX2Positive_limit.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX2Positive_limit.Location = new System.Drawing.Point(655, 87);
            this.lblScrewServoX2Positive_limit.Name = "lblScrewServoX2Positive_limit";
            this.lblScrewServoX2Positive_limit.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX2Positive_limit.TabIndex = 59;
            // 
            // label498
            // 
            this.label498.AutoSize = true;
            this.label498.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label498.Location = new System.Drawing.Point(561, 94);
            this.label498.Name = "label498";
            this.label498.Size = new System.Drawing.Size(89, 14);
            this.label498.TabIndex = 56;
            this.label498.Text = "Positive Limit";
            // 
            // lblScrewServoX2Home
            // 
            this.lblScrewServoX2Home.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX2Home.Location = new System.Drawing.Point(461, 36);
            this.lblScrewServoX2Home.Name = "lblScrewServoX2Home";
            this.lblScrewServoX2Home.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX2Home.TabIndex = 48;
            // 
            // lblScrewServoX2Running
            // 
            this.lblScrewServoX2Running.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX2Running.Location = new System.Drawing.Point(285, 87);
            this.lblScrewServoX2Running.Name = "lblScrewServoX2Running";
            this.lblScrewServoX2Running.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX2Running.TabIndex = 47;
            // 
            // lblScrewServoX2Ready
            // 
            this.lblScrewServoX2Ready.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX2Ready.Location = new System.Drawing.Point(285, 33);
            this.lblScrewServoX2Ready.Name = "lblScrewServoX2Ready";
            this.lblScrewServoX2Ready.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX2Ready.TabIndex = 46;
            // 
            // lblScrewServoX2Negative_limit
            // 
            this.lblScrewServoX2Negative_limit.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX2Negative_limit.Location = new System.Drawing.Point(655, 33);
            this.lblScrewServoX2Negative_limit.Name = "lblScrewServoX2Negative_limit";
            this.lblScrewServoX2Negative_limit.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX2Negative_limit.TabIndex = 45;
            // 
            // lblScrewServoX2Enable
            // 
            this.lblScrewServoX2Enable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoX2Enable.Location = new System.Drawing.Point(105, 33);
            this.lblScrewServoX2Enable.Name = "lblScrewServoX2Enable";
            this.lblScrewServoX2Enable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoX2Enable.TabIndex = 45;
            // 
            // label504
            // 
            this.label504.AutoSize = true;
            this.label504.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label504.Location = new System.Drawing.Point(187, 94);
            this.label504.Name = "label504";
            this.label504.Size = new System.Drawing.Size(98, 14);
            this.label504.TabIndex = 43;
            this.label504.Text = "Servo Running";
            // 
            // label505
            // 
            this.label505.AutoSize = true;
            this.label505.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label505.Location = new System.Drawing.Point(379, 44);
            this.label505.Name = "label505";
            this.label505.Size = new System.Drawing.Size(81, 14);
            this.label505.TabIndex = 41;
            this.label505.Text = "Servo Home";
            // 
            // label506
            // 
            this.label506.AutoSize = true;
            this.label506.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label506.Location = new System.Drawing.Point(556, 41);
            this.label506.Name = "label506";
            this.label506.Size = new System.Drawing.Size(94, 14);
            this.label506.TabIndex = 37;
            this.label506.Text = "Negative Limit";
            // 
            // label507
            // 
            this.label507.AutoSize = true;
            this.label507.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label507.Location = new System.Drawing.Point(201, 41);
            this.label507.Name = "label507";
            this.label507.Size = new System.Drawing.Size(84, 14);
            this.label507.TabIndex = 39;
            this.label507.Text = "Servo Ready";
            // 
            // label508
            // 
            this.label508.AutoSize = true;
            this.label508.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label508.Location = new System.Drawing.Point(15, 41);
            this.label508.Name = "label508";
            this.label508.Size = new System.Drawing.Size(86, 14);
            this.label508.TabIndex = 37;
            this.label508.Text = "Servo Enable";
            // 
            // AxisX1
            // 
            this.AxisX1.BackColor = System.Drawing.Color.LightGray;
            this.AxisX1.Controls.Add(this.groupBox51);
            this.AxisX1.Location = new System.Drawing.Point(4, 29);
            this.AxisX1.Name = "AxisX1";
            this.AxisX1.Padding = new System.Windows.Forms.Padding(3);
            this.AxisX1.Size = new System.Drawing.Size(1371, 542);
            this.AxisX1.TabIndex = 1;
            this.AxisX1.Text = "X1 - Axis";
            // 
            // groupBox51
            // 
            this.groupBox51.BackColor = System.Drawing.Color.White;
            this.groupBox51.Controls.Add(this.groupBox52);
            this.groupBox51.Controls.Add(this.groupBox61);
            this.groupBox51.Controls.Add(this.groupBox62);
            this.groupBox51.Controls.Add(this.groupBox63);
            this.groupBox51.Controls.Add(this.groupBox64);
            this.groupBox51.Controls.Add(this.groupBox65);
            this.groupBox51.Controls.Add(this.groupBox66);
            this.groupBox51.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox51.Location = new System.Drawing.Point(239, 47);
            this.groupBox51.Name = "groupBox51";
            this.groupBox51.Size = new System.Drawing.Size(1116, 485);
            this.groupBox51.TabIndex = 41;
            this.groupBox51.TabStop = false;
            // 
            // groupBox52
            // 
            this.groupBox52.Controls.Add(this.Btn_ScrewServo_Enable_Y1);
            this.groupBox52.Controls.Add(this.btnScrewServoY1ClearErr);
            this.groupBox52.Controls.Add(this.Btn_ScrewServo_disable_Y1);
            this.groupBox52.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox52.Location = new System.Drawing.Point(49, 149);
            this.groupBox52.Name = "groupBox52";
            this.groupBox52.Size = new System.Drawing.Size(177, 168);
            this.groupBox52.TabIndex = 75;
            this.groupBox52.TabStop = false;
            this.groupBox52.Text = "Device Control";
            // 
            // Btn_ScrewServo_Enable_Y1
            // 
            this.Btn_ScrewServo_Enable_Y1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_Enable_Y1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_Enable_Y1.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_Enable_Y1.Location = new System.Drawing.Point(11, 26);
            this.Btn_ScrewServo_Enable_Y1.Name = "Btn_ScrewServo_Enable_Y1";
            this.Btn_ScrewServo_Enable_Y1.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_Enable_Y1.TabIndex = 71;
            this.Btn_ScrewServo_Enable_Y1.Text = "Servo Enable";
            this.Btn_ScrewServo_Enable_Y1.UseVisualStyleBackColor = false;
            // 
            // btnScrewServoY1ClearErr
            // 
            this.btnScrewServoY1ClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewServoY1ClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewServoY1ClearErr.ForeColor = System.Drawing.Color.White;
            this.btnScrewServoY1ClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnScrewServoY1ClearErr.Name = "btnScrewServoY1ClearErr";
            this.btnScrewServoY1ClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnScrewServoY1ClearErr.TabIndex = 71;
            this.btnScrewServoY1ClearErr.Text = "Servo Clear Error";
            this.btnScrewServoY1ClearErr.UseVisualStyleBackColor = false;
            // 
            // Btn_ScrewServo_disable_Y1
            // 
            this.Btn_ScrewServo_disable_Y1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_disable_Y1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_disable_Y1.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_disable_Y1.Location = new System.Drawing.Point(11, 70);
            this.Btn_ScrewServo_disable_Y1.Name = "Btn_ScrewServo_disable_Y1";
            this.Btn_ScrewServo_disable_Y1.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_disable_Y1.TabIndex = 71;
            this.Btn_ScrewServo_disable_Y1.Text = "Servo Disable";
            this.Btn_ScrewServo_disable_Y1.UseVisualStyleBackColor = false;
            // 
            // groupBox61
            // 
            this.groupBox61.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox61.Controls.Add(this.label216);
            this.groupBox61.Controls.Add(this.lbl_Y1ScrewServo_ActualPosition);
            this.groupBox61.Controls.Add(this.label218);
            this.groupBox61.Controls.Add(this.label219);
            this.groupBox61.Controls.Add(this.label223);
            this.groupBox61.Controls.Add(this.lbl_Y1ScrewSV_TP);
            this.groupBox61.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox61.Location = new System.Drawing.Point(732, 14);
            this.groupBox61.Name = "groupBox61";
            this.groupBox61.Size = new System.Drawing.Size(363, 128);
            this.groupBox61.TabIndex = 74;
            this.groupBox61.TabStop = false;
            this.groupBox61.Text = "Live Values";
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label216.Location = new System.Drawing.Point(299, 86);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(37, 14);
            this.label216.TabIndex = 73;
            this.label216.Text = "(mm)";
            // 
            // lbl_Y1ScrewServo_ActualPosition
            // 
            this.lbl_Y1ScrewServo_ActualPosition.AutoSize = true;
            this.lbl_Y1ScrewServo_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Y1ScrewServo_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Y1ScrewServo_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Y1ScrewServo_ActualPosition.Location = new System.Drawing.Point(191, 42);
            this.lbl_Y1ScrewServo_ActualPosition.Name = "lbl_Y1ScrewServo_ActualPosition";
            this.lbl_Y1ScrewServo_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_Y1ScrewServo_ActualPosition.TabIndex = 53;
            this.lbl_Y1ScrewServo_ActualPosition.Text = "0";
            this.lbl_Y1ScrewServo_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label218
            // 
            this.label218.AutoSize = true;
            this.label218.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label218.Location = new System.Drawing.Point(299, 45);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(37, 14);
            this.label218.TabIndex = 75;
            this.label218.Text = "(mm)";
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label219.Location = new System.Drawing.Point(28, 46);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(139, 14);
            this.label219.TabIndex = 52;
            this.label219.Text = "Servo Actual Position";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label223.Location = new System.Drawing.Point(28, 83);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(140, 14);
            this.label223.TabIndex = 54;
            this.label223.Text = "Servo Target Position";
            // 
            // lbl_Y1ScrewSV_TP
            // 
            this.lbl_Y1ScrewSV_TP.AutoSize = true;
            this.lbl_Y1ScrewSV_TP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Y1ScrewSV_TP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Y1ScrewSV_TP.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Y1ScrewSV_TP.Location = new System.Drawing.Point(191, 83);
            this.lbl_Y1ScrewSV_TP.Name = "lbl_Y1ScrewSV_TP";
            this.lbl_Y1ScrewSV_TP.Size = new System.Drawing.Size(18, 16);
            this.lbl_Y1ScrewSV_TP.TabIndex = 55;
            this.lbl_Y1ScrewSV_TP.Text = "0";
            this.lbl_Y1ScrewSV_TP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox62
            // 
            this.groupBox62.Controls.Add(this.button26);
            this.groupBox62.Controls.Add(this.button27);
            this.groupBox62.Controls.Add(this.textBox33);
            this.groupBox62.Controls.Add(this.textBox37);
            this.groupBox62.Controls.Add(this.textBox38);
            this.groupBox62.Controls.Add(this.label225);
            this.groupBox62.Controls.Add(this.label226);
            this.groupBox62.Controls.Add(this.textBox39);
            this.groupBox62.Controls.Add(this.label227);
            this.groupBox62.Controls.Add(this.textBox40);
            this.groupBox62.Controls.Add(this.label228);
            this.groupBox62.Controls.Add(this.label230);
            this.groupBox62.Controls.Add(this.label231);
            this.groupBox62.Controls.Add(this.label232);
            this.groupBox62.Controls.Add(this.label233);
            this.groupBox62.Controls.Add(this.label234);
            this.groupBox62.Controls.Add(this.label235);
            this.groupBox62.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox62.Location = new System.Drawing.Point(155, 326);
            this.groupBox62.Name = "groupBox62";
            this.groupBox62.Size = new System.Drawing.Size(781, 149);
            this.groupBox62.TabIndex = 73;
            this.groupBox62.TabStop = false;
            this.groupBox62.Text = "Point To Point Control";
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button26.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.ForeColor = System.Drawing.Color.White;
            this.button26.Location = new System.Drawing.Point(399, 103);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(83, 38);
            this.button26.TabIndex = 71;
            this.button26.Text = "Stop";
            this.button26.UseVisualStyleBackColor = false;
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button27.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.ForeColor = System.Drawing.Color.White;
            this.button27.Location = new System.Drawing.Point(203, 103);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(83, 38);
            this.button27.TabIndex = 70;
            this.button27.Text = "Move";
            this.button27.UseVisualStyleBackColor = false;
            // 
            // textBox33
            // 
            this.textBox33.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox33.Location = new System.Drawing.Point(603, 28);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(67, 26);
            this.textBox33.TabIndex = 61;
            // 
            // textBox37
            // 
            this.textBox37.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox37.Location = new System.Drawing.Point(336, 65);
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new System.Drawing.Size(67, 26);
            this.textBox37.TabIndex = 61;
            // 
            // textBox38
            // 
            this.textBox38.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox38.Location = new System.Drawing.Point(336, 28);
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(67, 26);
            this.textBox38.TabIndex = 61;
            // 
            // label225
            // 
            this.label225.AutoSize = true;
            this.label225.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label225.Location = new System.Drawing.Point(21, 80);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(84, 14);
            this.label225.TabIndex = 37;
            this.label225.Text = "End Position";
            // 
            // label226
            // 
            this.label226.AutoSize = true;
            this.label226.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label226.Location = new System.Drawing.Point(14, 40);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(93, 14);
            this.label226.TabIndex = 37;
            this.label226.Text = "Start Position";
            // 
            // textBox39
            // 
            this.textBox39.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox39.Location = new System.Drawing.Point(105, 71);
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new System.Drawing.Size(67, 26);
            this.textBox39.TabIndex = 59;
            // 
            // label227
            // 
            this.label227.AutoSize = true;
            this.label227.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label227.Location = new System.Drawing.Point(539, 40);
            this.label227.Name = "label227";
            this.label227.Size = new System.Drawing.Size(62, 14);
            this.label227.TabIndex = 60;
            this.label227.Text = "Iteration";
            // 
            // textBox40
            // 
            this.textBox40.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox40.Location = new System.Drawing.Point(105, 32);
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new System.Drawing.Size(67, 26);
            this.textBox40.TabIndex = 59;
            // 
            // label228
            // 
            this.label228.AutoSize = true;
            this.label228.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label228.Location = new System.Drawing.Point(297, 76);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(35, 14);
            this.label228.TabIndex = 60;
            this.label228.Text = "Wait";
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label230.Location = new System.Drawing.Point(179, 80);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(37, 14);
            this.label230.TabIndex = 66;
            this.label230.Text = "(mm)";
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label231.Location = new System.Drawing.Point(676, 40);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(39, 14);
            this.label231.TabIndex = 67;
            this.label231.Text = "count";
            // 
            // label232
            // 
            this.label232.AutoSize = true;
            this.label232.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label232.Location = new System.Drawing.Point(287, 40);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(45, 14);
            this.label232.TabIndex = 60;
            this.label232.Text = "Speed";
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label233.Location = new System.Drawing.Point(410, 76);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(25, 14);
            this.label233.TabIndex = 67;
            this.label233.Text = "sec";
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label234.Location = new System.Drawing.Point(179, 40);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(37, 14);
            this.label234.TabIndex = 66;
            this.label234.Text = "(mm)";
            // 
            // label235
            // 
            this.label235.AutoSize = true;
            this.label235.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label235.Location = new System.Drawing.Point(410, 40);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(47, 14);
            this.label235.TabIndex = 67;
            this.label235.Text = "(mm/s)";
            // 
            // groupBox63
            // 
            this.groupBox63.BackColor = System.Drawing.Color.White;
            this.groupBox63.Controls.Add(this.comboBox2);
            this.groupBox63.Controls.Add(this.label236);
            this.groupBox63.Controls.Add(this.textBox41);
            this.groupBox63.Controls.Add(this.label237);
            this.groupBox63.Controls.Add(this.label238);
            this.groupBox63.Controls.Add(this.button28);
            this.groupBox63.Controls.Add(this.button29);
            this.groupBox63.Controls.Add(this.label239);
            this.groupBox63.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox63.Location = new System.Drawing.Point(827, 149);
            this.groupBox63.Name = "groupBox63";
            this.groupBox63.Size = new System.Drawing.Size(234, 168);
            this.groupBox63.TabIndex = 72;
            this.groupBox63.TabStop = false;
            this.groupBox63.Text = "Jog Control";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox2.Location = new System.Drawing.Point(105, 64);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(67, 26);
            this.comboBox2.TabIndex = 78;
            this.comboBox2.Visible = false;
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label236.Location = new System.Drawing.Point(176, 41);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(37, 14);
            this.label236.TabIndex = 77;
            this.label236.Text = "(mm)";
            this.label236.Visible = false;
            // 
            // textBox41
            // 
            this.textBox41.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox41.Location = new System.Drawing.Point(105, 32);
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new System.Drawing.Size(67, 26);
            this.textBox41.TabIndex = 76;
            this.textBox41.Visible = false;
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label237.Location = new System.Drawing.Point(20, 40);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(83, 14);
            this.label237.TabIndex = 75;
            this.label237.Text = "Jog Position";
            this.label237.Visible = false;
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label238.Location = new System.Drawing.Point(172, 71);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(47, 14);
            this.label238.TabIndex = 73;
            this.label238.Text = "(mm/s)";
            this.label238.Visible = false;
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button28.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button28.ForeColor = System.Drawing.Color.White;
            this.button28.Location = new System.Drawing.Point(129, 107);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(83, 38);
            this.button28.TabIndex = 74;
            this.button28.Text = "Jog -";
            this.button28.UseVisualStyleBackColor = false;
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button29.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.ForeColor = System.Drawing.Color.White;
            this.button29.Location = new System.Drawing.Point(24, 107);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(83, 38);
            this.button29.TabIndex = 73;
            this.button29.Text = "Jog +";
            this.button29.UseVisualStyleBackColor = false;
            // 
            // label239
            // 
            this.label239.AutoSize = true;
            this.label239.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label239.Location = new System.Drawing.Point(20, 72);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(81, 14);
            this.label239.TabIndex = 37;
            this.label239.Text = "Jog Velocity";
            this.label239.Visible = false;
            // 
            // groupBox64
            // 
            this.groupBox64.BackColor = System.Drawing.Color.White;
            this.groupBox64.Controls.Add(this.btn_Y1stop_home);
            this.groupBox64.Controls.Add(this.label240);
            this.groupBox64.Controls.Add(this.btnScrewHome_Y1);
            this.groupBox64.Controls.Add(this.textBox42);
            this.groupBox64.Controls.Add(this.label241);
            this.groupBox64.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox64.Location = new System.Drawing.Point(539, 153);
            this.groupBox64.Name = "groupBox64";
            this.groupBox64.Size = new System.Drawing.Size(234, 165);
            this.groupBox64.TabIndex = 71;
            this.groupBox64.TabStop = false;
            this.groupBox64.Text = "Homing Control";
            // 
            // btn_Y1stop_home
            // 
            this.btn_Y1stop_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_Y1stop_home.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Y1stop_home.ForeColor = System.Drawing.Color.White;
            this.btn_Y1stop_home.Location = new System.Drawing.Point(126, 105);
            this.btn_Y1stop_home.Name = "btn_Y1stop_home";
            this.btn_Y1stop_home.Size = new System.Drawing.Size(83, 38);
            this.btn_Y1stop_home.TabIndex = 72;
            this.btn_Y1stop_home.Text = "Stop";
            this.btn_Y1stop_home.UseVisualStyleBackColor = false;
            // 
            // label240
            // 
            this.label240.AutoSize = true;
            this.label240.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label240.Location = new System.Drawing.Point(179, 55);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(47, 14);
            this.label240.TabIndex = 72;
            this.label240.Text = "(mm/s)";
            // 
            // btnScrewHome_Y1
            // 
            this.btnScrewHome_Y1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewHome_Y1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewHome_Y1.ForeColor = System.Drawing.Color.White;
            this.btnScrewHome_Y1.Location = new System.Drawing.Point(23, 105);
            this.btnScrewHome_Y1.Name = "btnScrewHome_Y1";
            this.btnScrewHome_Y1.Size = new System.Drawing.Size(83, 38);
            this.btnScrewHome_Y1.TabIndex = 72;
            this.btnScrewHome_Y1.Text = "Home";
            this.btnScrewHome_Y1.UseVisualStyleBackColor = false;
            // 
            // textBox42
            // 
            this.textBox42.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox42.Location = new System.Drawing.Point(108, 47);
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new System.Drawing.Size(67, 26);
            this.textBox42.TabIndex = 59;
            // 
            // label241
            // 
            this.label241.AutoSize = true;
            this.label241.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label241.Location = new System.Drawing.Point(9, 55);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(94, 14);
            this.label241.TabIndex = 37;
            this.label241.Text = "Home Velocity";
            // 
            // groupBox65
            // 
            this.groupBox65.BackColor = System.Drawing.Color.White;
            this.groupBox65.Controls.Add(this.button32);
            this.groupBox65.Controls.Add(this.btnScrewSVMove_Y1);
            this.groupBox65.Controls.Add(this.label243);
            this.groupBox65.Controls.Add(this.label244);
            this.groupBox65.Controls.Add(this.lbl_Y1ScrewSV_Speed);
            this.groupBox65.Controls.Add(this.label245);
            this.groupBox65.Controls.Add(this.lbl_Y1ScrewSV_TargetPosition);
            this.groupBox65.Controls.Add(this.label246);
            this.groupBox65.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox65.Location = new System.Drawing.Point(275, 149);
            this.groupBox65.Name = "groupBox65";
            this.groupBox65.Size = new System.Drawing.Size(223, 168);
            this.groupBox65.TabIndex = 56;
            this.groupBox65.TabStop = false;
            this.groupBox65.Text = "Motion Control";
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button32.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.ForeColor = System.Drawing.Color.White;
            this.button32.Location = new System.Drawing.Point(117, 107);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(83, 38);
            this.button32.TabIndex = 72;
            this.button32.Text = "Stop";
            this.button32.UseVisualStyleBackColor = false;
            // 
            // btnScrewSVMove_Y1
            // 
            this.btnScrewSVMove_Y1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewSVMove_Y1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewSVMove_Y1.ForeColor = System.Drawing.Color.White;
            this.btnScrewSVMove_Y1.Location = new System.Drawing.Point(21, 107);
            this.btnScrewSVMove_Y1.Name = "btnScrewSVMove_Y1";
            this.btnScrewSVMove_Y1.Size = new System.Drawing.Size(83, 38);
            this.btnScrewSVMove_Y1.TabIndex = 70;
            this.btnScrewSVMove_Y1.Text = "Move";
            this.btnScrewSVMove_Y1.UseVisualStyleBackColor = false;
            // 
            // label243
            // 
            this.label243.AutoSize = true;
            this.label243.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label243.Location = new System.Drawing.Point(158, 79);
            this.label243.Name = "label243";
            this.label243.Size = new System.Drawing.Size(47, 14);
            this.label243.TabIndex = 67;
            this.label243.Text = "(mm/s)";
            // 
            // label244
            // 
            this.label244.AutoSize = true;
            this.label244.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label244.Location = new System.Drawing.Point(158, 37);
            this.label244.Name = "label244";
            this.label244.Size = new System.Drawing.Size(37, 14);
            this.label244.TabIndex = 66;
            this.label244.Text = "(mm)";
            // 
            // lbl_Y1ScrewSV_Speed
            // 
            this.lbl_Y1ScrewSV_Speed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Y1ScrewSV_Speed.Location = new System.Drawing.Point(84, 66);
            this.lbl_Y1ScrewSV_Speed.Name = "lbl_Y1ScrewSV_Speed";
            this.lbl_Y1ScrewSV_Speed.Size = new System.Drawing.Size(67, 26);
            this.lbl_Y1ScrewSV_Speed.TabIndex = 61;
            // 
            // label245
            // 
            this.label245.AutoSize = true;
            this.label245.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label245.Location = new System.Drawing.Point(22, 73);
            this.label245.Name = "label245";
            this.label245.Size = new System.Drawing.Size(45, 14);
            this.label245.TabIndex = 60;
            this.label245.Text = "Speed";
            // 
            // lbl_Y1ScrewSV_TargetPosition
            // 
            this.lbl_Y1ScrewSV_TargetPosition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Y1ScrewSV_TargetPosition.Location = new System.Drawing.Point(84, 29);
            this.lbl_Y1ScrewSV_TargetPosition.Name = "lbl_Y1ScrewSV_TargetPosition";
            this.lbl_Y1ScrewSV_TargetPosition.Size = new System.Drawing.Size(67, 26);
            this.lbl_Y1ScrewSV_TargetPosition.TabIndex = 59;
            // 
            // label246
            // 
            this.label246.AutoSize = true;
            this.label246.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label246.Location = new System.Drawing.Point(22, 36);
            this.label246.Name = "label246";
            this.label246.Size = new System.Drawing.Size(57, 14);
            this.label246.TabIndex = 37;
            this.label246.Text = "Position";
            // 
            // groupBox66
            // 
            this.groupBox66.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox66.Controls.Add(this.lblScrewServoY1disable);
            this.groupBox66.Controls.Add(this.label268);
            this.groupBox66.Controls.Add(this.lblScrewServoY1Error);
            this.groupBox66.Controls.Add(this.label272);
            this.groupBox66.Controls.Add(this.lblScrewServoY1Home);
            this.groupBox66.Controls.Add(this.lblScrewServoY1Running);
            this.groupBox66.Controls.Add(this.lblScrewServoY1Ready);
            this.groupBox66.Controls.Add(this.lblScrewServoY1Enable);
            this.groupBox66.Controls.Add(this.label285);
            this.groupBox66.Controls.Add(this.label286);
            this.groupBox66.Controls.Add(this.label288);
            this.groupBox66.Controls.Add(this.label289);
            this.groupBox66.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox66.Location = new System.Drawing.Point(15, 14);
            this.groupBox66.Name = "groupBox66";
            this.groupBox66.Size = new System.Drawing.Size(699, 128);
            this.groupBox66.TabIndex = 37;
            this.groupBox66.TabStop = false;
            this.groupBox66.Text = "Device Status";
            // 
            // lblScrewServoY1disable
            // 
            this.lblScrewServoY1disable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoY1disable.Location = new System.Drawing.Point(177, 83);
            this.lblScrewServoY1disable.Name = "lblScrewServoY1disable";
            this.lblScrewServoY1disable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoY1disable.TabIndex = 63;
            // 
            // label268
            // 
            this.label268.AutoSize = true;
            this.label268.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label268.Location = new System.Drawing.Point(86, 92);
            this.label268.Name = "label268";
            this.label268.Size = new System.Drawing.Size(89, 14);
            this.label268.TabIndex = 62;
            this.label268.Text = "Servo Disable";
            // 
            // lblScrewServoY1Error
            // 
            this.lblScrewServoY1Error.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoY1Error.Location = new System.Drawing.Point(533, 80);
            this.lblScrewServoY1Error.Name = "lblScrewServoY1Error";
            this.lblScrewServoY1Error.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoY1Error.TabIndex = 61;
            // 
            // label272
            // 
            this.label272.AutoSize = true;
            this.label272.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label272.Location = new System.Drawing.Point(439, 88);
            this.label272.Name = "label272";
            this.label272.Size = new System.Drawing.Size(93, 14);
            this.label272.TabIndex = 60;
            this.label272.Text = "Servo In Error";
            // 
            // lblScrewServoY1Home
            // 
            this.lblScrewServoY1Home.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoY1Home.Location = new System.Drawing.Point(533, 29);
            this.lblScrewServoY1Home.Name = "lblScrewServoY1Home";
            this.lblScrewServoY1Home.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoY1Home.TabIndex = 48;
            // 
            // lblScrewServoY1Running
            // 
            this.lblScrewServoY1Running.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoY1Running.Location = new System.Drawing.Point(357, 80);
            this.lblScrewServoY1Running.Name = "lblScrewServoY1Running";
            this.lblScrewServoY1Running.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoY1Running.TabIndex = 47;
            // 
            // lblScrewServoY1Ready
            // 
            this.lblScrewServoY1Ready.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoY1Ready.Location = new System.Drawing.Point(357, 26);
            this.lblScrewServoY1Ready.Name = "lblScrewServoY1Ready";
            this.lblScrewServoY1Ready.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoY1Ready.TabIndex = 46;
            // 
            // lblScrewServoY1Enable
            // 
            this.lblScrewServoY1Enable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoY1Enable.Location = new System.Drawing.Point(177, 26);
            this.lblScrewServoY1Enable.Name = "lblScrewServoY1Enable";
            this.lblScrewServoY1Enable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoY1Enable.TabIndex = 45;
            // 
            // label285
            // 
            this.label285.AutoSize = true;
            this.label285.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label285.Location = new System.Drawing.Point(259, 88);
            this.label285.Name = "label285";
            this.label285.Size = new System.Drawing.Size(98, 14);
            this.label285.TabIndex = 43;
            this.label285.Text = "Servo Running";
            // 
            // label286
            // 
            this.label286.AutoSize = true;
            this.label286.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label286.Location = new System.Drawing.Point(451, 37);
            this.label286.Name = "label286";
            this.label286.Size = new System.Drawing.Size(81, 14);
            this.label286.TabIndex = 41;
            this.label286.Text = "Servo Home";
            // 
            // label288
            // 
            this.label288.AutoSize = true;
            this.label288.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label288.Location = new System.Drawing.Point(273, 34);
            this.label288.Name = "label288";
            this.label288.Size = new System.Drawing.Size(84, 14);
            this.label288.TabIndex = 39;
            this.label288.Text = "Servo Ready";
            // 
            // label289
            // 
            this.label289.AutoSize = true;
            this.label289.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label289.Location = new System.Drawing.Point(87, 34);
            this.label289.Name = "label289";
            this.label289.Size = new System.Drawing.Size(86, 14);
            this.label289.TabIndex = 37;
            this.label289.Text = "Servo Enable";
            // 
            // AxisX2
            // 
            this.AxisX2.BackColor = System.Drawing.Color.LightGray;
            this.AxisX2.Controls.Add(this.groupBox4);
            this.AxisX2.Location = new System.Drawing.Point(4, 29);
            this.AxisX2.Name = "AxisX2";
            this.AxisX2.Size = new System.Drawing.Size(1371, 542);
            this.AxisX2.TabIndex = 5;
            this.AxisX2.Text = "X2 - Axis";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox31);
            this.groupBox4.Controls.Add(this.groupBox33);
            this.groupBox4.Controls.Add(this.groupBox38);
            this.groupBox4.Controls.Add(this.groupBox39);
            this.groupBox4.Controls.Add(this.groupBox79);
            this.groupBox4.Controls.Add(this.groupBox80);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(239, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1116, 485);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button1);
            this.groupBox9.Controls.Add(this.button2);
            this.groupBox9.Controls.Add(this.button3);
            this.groupBox9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(49, 149);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(177, 168);
            this.groupBox9.TabIndex = 75;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Device Control";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(11, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 38);
            this.button1.TabIndex = 71;
            this.button1.Text = "Servo Enable";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(11, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 38);
            this.button2.TabIndex = 71;
            this.button2.Text = "Servo Clear Error";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(11, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 38);
            this.button3.TabIndex = 71;
            this.button3.Text = "Servo Disable";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // groupBox31
            // 
            this.groupBox31.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox31.Controls.Add(this.label42);
            this.groupBox31.Controls.Add(this.lblActPosAX2);
            this.groupBox31.Controls.Add(this.label64);
            this.groupBox31.Controls.Add(this.label65);
            this.groupBox31.Controls.Add(this.label66);
            this.groupBox31.Controls.Add(this.label67);
            this.groupBox31.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox31.Location = new System.Drawing.Point(732, 14);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(363, 128);
            this.groupBox31.TabIndex = 74;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Live Values";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(299, 86);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(37, 14);
            this.label42.TabIndex = 73;
            this.label42.Text = "(mm)";
            // 
            // lblActPosAX2
            // 
            this.lblActPosAX2.AutoSize = true;
            this.lblActPosAX2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblActPosAX2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblActPosAX2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActPosAX2.Location = new System.Drawing.Point(191, 42);
            this.lblActPosAX2.Name = "lblActPosAX2";
            this.lblActPosAX2.Size = new System.Drawing.Size(18, 16);
            this.lblActPosAX2.TabIndex = 53;
            this.lblActPosAX2.Text = "0";
            this.lblActPosAX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.Location = new System.Drawing.Point(299, 45);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(37, 14);
            this.label64.TabIndex = 75;
            this.label64.Text = "(mm)";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(28, 46);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(139, 14);
            this.label65.TabIndex = 52;
            this.label65.Text = "Servo Actual Position";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(28, 83);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(140, 14);
            this.label66.TabIndex = 54;
            this.label66.Text = "Servo Target Position";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label67.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(191, 83);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(18, 16);
            this.label67.TabIndex = 55;
            this.label67.Text = "0";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.button7);
            this.groupBox33.Controls.Add(this.button8);
            this.groupBox33.Controls.Add(this.textBox1);
            this.groupBox33.Controls.Add(this.textBox7);
            this.groupBox33.Controls.Add(this.textBox9);
            this.groupBox33.Controls.Add(this.label68);
            this.groupBox33.Controls.Add(this.label69);
            this.groupBox33.Controls.Add(this.textBox10);
            this.groupBox33.Controls.Add(this.label70);
            this.groupBox33.Controls.Add(this.textBox14);
            this.groupBox33.Controls.Add(this.label71);
            this.groupBox33.Controls.Add(this.label74);
            this.groupBox33.Controls.Add(this.label76);
            this.groupBox33.Controls.Add(this.label78);
            this.groupBox33.Controls.Add(this.label79);
            this.groupBox33.Controls.Add(this.label81);
            this.groupBox33.Controls.Add(this.label82);
            this.groupBox33.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox33.Location = new System.Drawing.Point(155, 326);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(781, 149);
            this.groupBox33.TabIndex = 73;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Point To Point Control";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button7.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(399, 103);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(83, 38);
            this.button7.TabIndex = 71;
            this.button7.Text = "Stop";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button8.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(203, 103);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(83, 38);
            this.button8.TabIndex = 70;
            this.button8.Text = "Move";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(603, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 26);
            this.textBox1.TabIndex = 61;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(336, 65);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(67, 26);
            this.textBox7.TabIndex = 61;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(336, 28);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(67, 26);
            this.textBox9.TabIndex = 61;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(21, 80);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(84, 14);
            this.label68.TabIndex = 37;
            this.label68.Text = "End Position";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(14, 40);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(93, 14);
            this.label69.TabIndex = 37;
            this.label69.Text = "Start Position";
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(105, 71);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(67, 26);
            this.textBox10.TabIndex = 59;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(539, 40);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(62, 14);
            this.label70.TabIndex = 60;
            this.label70.Text = "Iteration";
            // 
            // textBox14
            // 
            this.textBox14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(105, 32);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(67, 26);
            this.textBox14.TabIndex = 59;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(297, 76);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(35, 14);
            this.label71.TabIndex = 60;
            this.label71.Text = "Wait";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(179, 80);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(37, 14);
            this.label74.TabIndex = 66;
            this.label74.Text = "(mm)";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(676, 40);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(39, 14);
            this.label76.TabIndex = 67;
            this.label76.Text = "count";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.Location = new System.Drawing.Point(287, 40);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(45, 14);
            this.label78.TabIndex = 60;
            this.label78.Text = "Speed";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.Location = new System.Drawing.Point(410, 76);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(25, 14);
            this.label79.TabIndex = 67;
            this.label79.Text = "sec";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.Location = new System.Drawing.Point(179, 40);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(37, 14);
            this.label81.TabIndex = 66;
            this.label81.Text = "(mm)";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.Location = new System.Drawing.Point(410, 40);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(47, 14);
            this.label82.TabIndex = 67;
            this.label82.Text = "(mm/s)";
            // 
            // groupBox38
            // 
            this.groupBox38.BackColor = System.Drawing.Color.White;
            this.groupBox38.Controls.Add(this.comboBox10);
            this.groupBox38.Controls.Add(this.label84);
            this.groupBox38.Controls.Add(this.textBox30);
            this.groupBox38.Controls.Add(this.label85);
            this.groupBox38.Controls.Add(this.label86);
            this.groupBox38.Controls.Add(this.button9);
            this.groupBox38.Controls.Add(this.button10);
            this.groupBox38.Controls.Add(this.label87);
            this.groupBox38.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox38.Location = new System.Drawing.Point(827, 149);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(234, 168);
            this.groupBox38.TabIndex = 72;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Jog Control";
            // 
            // comboBox10
            // 
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox10.Location = new System.Drawing.Point(105, 64);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(67, 26);
            this.comboBox10.TabIndex = 78;
            this.comboBox10.Visible = false;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.Location = new System.Drawing.Point(176, 41);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(37, 14);
            this.label84.TabIndex = 77;
            this.label84.Text = "(mm)";
            this.label84.Visible = false;
            // 
            // textBox30
            // 
            this.textBox30.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox30.Location = new System.Drawing.Point(105, 32);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(67, 26);
            this.textBox30.TabIndex = 76;
            this.textBox30.Visible = false;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.Location = new System.Drawing.Point(20, 40);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(83, 14);
            this.label85.TabIndex = 75;
            this.label85.Text = "Jog Position";
            this.label85.Visible = false;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.Location = new System.Drawing.Point(172, 71);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(47, 14);
            this.label86.TabIndex = 73;
            this.label86.Text = "(mm/s)";
            this.label86.Visible = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button9.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(129, 107);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(83, 38);
            this.button9.TabIndex = 74;
            this.button9.Text = "Jog -";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button10.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(24, 107);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(83, 38);
            this.button10.TabIndex = 73;
            this.button10.Text = "Jog +";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(20, 72);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(81, 14);
            this.label87.TabIndex = 37;
            this.label87.Text = "Jog Velocity";
            this.label87.Visible = false;
            // 
            // groupBox39
            // 
            this.groupBox39.BackColor = System.Drawing.Color.White;
            this.groupBox39.Controls.Add(this.button11);
            this.groupBox39.Controls.Add(this.label88);
            this.groupBox39.Controls.Add(this.button12);
            this.groupBox39.Controls.Add(this.textBox32);
            this.groupBox39.Controls.Add(this.label89);
            this.groupBox39.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox39.Location = new System.Drawing.Point(539, 153);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(234, 165);
            this.groupBox39.TabIndex = 71;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "Homing Control";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button11.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(126, 105);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(83, 38);
            this.button11.TabIndex = 72;
            this.button11.Text = "Stop";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(179, 55);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(47, 14);
            this.label88.TabIndex = 72;
            this.label88.Text = "(mm/s)";
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button12.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(23, 105);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(83, 38);
            this.button12.TabIndex = 72;
            this.button12.Text = "Home";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // textBox32
            // 
            this.textBox32.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox32.Location = new System.Drawing.Point(108, 47);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(67, 26);
            this.textBox32.TabIndex = 59;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(9, 55);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(94, 14);
            this.label89.TabIndex = 37;
            this.label89.Text = "Home Velocity";
            // 
            // groupBox79
            // 
            this.groupBox79.BackColor = System.Drawing.Color.White;
            this.groupBox79.Controls.Add(this.button13);
            this.groupBox79.Controls.Add(this.button14);
            this.groupBox79.Controls.Add(this.label106);
            this.groupBox79.Controls.Add(this.label108);
            this.groupBox79.Controls.Add(this.txtTargSpdAX2);
            this.groupBox79.Controls.Add(this.label111);
            this.groupBox79.Controls.Add(this.txtTargPosAX2);
            this.groupBox79.Controls.Add(this.label114);
            this.groupBox79.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox79.Location = new System.Drawing.Point(275, 149);
            this.groupBox79.Name = "groupBox79";
            this.groupBox79.Size = new System.Drawing.Size(223, 168);
            this.groupBox79.TabIndex = 56;
            this.groupBox79.TabStop = false;
            this.groupBox79.Text = "Motion Control";
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button13.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(117, 107);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(83, 38);
            this.button13.TabIndex = 72;
            this.button13.Text = "Stop";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button14.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(21, 107);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(83, 38);
            this.button14.TabIndex = 70;
            this.button14.Text = "Move";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(158, 79);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(47, 14);
            this.label106.TabIndex = 67;
            this.label106.Text = "(mm/s)";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label108.Location = new System.Drawing.Point(158, 37);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(37, 14);
            this.label108.TabIndex = 66;
            this.label108.Text = "(mm)";
            // 
            // txtTargSpdAX2
            // 
            this.txtTargSpdAX2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTargSpdAX2.Location = new System.Drawing.Point(84, 66);
            this.txtTargSpdAX2.Name = "txtTargSpdAX2";
            this.txtTargSpdAX2.Size = new System.Drawing.Size(67, 26);
            this.txtTargSpdAX2.TabIndex = 61;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.Location = new System.Drawing.Point(22, 73);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(45, 14);
            this.label111.TabIndex = 60;
            this.label111.Text = "Speed";
            // 
            // txtTargPosAX2
            // 
            this.txtTargPosAX2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTargPosAX2.Location = new System.Drawing.Point(84, 29);
            this.txtTargPosAX2.Name = "txtTargPosAX2";
            this.txtTargPosAX2.Size = new System.Drawing.Size(67, 26);
            this.txtTargPosAX2.TabIndex = 59;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.Location = new System.Drawing.Point(22, 36);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(57, 14);
            this.label114.TabIndex = 37;
            this.label114.Text = "Position";
            // 
            // groupBox80
            // 
            this.groupBox80.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox80.Controls.Add(this.txtAX2Disable);
            this.groupBox80.Controls.Add(this.label136);
            this.groupBox80.Controls.Add(this.label137);
            this.groupBox80.Controls.Add(this.label139);
            this.groupBox80.Controls.Add(this.label142);
            this.groupBox80.Controls.Add(this.label143);
            this.groupBox80.Controls.Add(this.label159);
            this.groupBox80.Controls.Add(this.txtAX2Enable);
            this.groupBox80.Controls.Add(this.label179);
            this.groupBox80.Controls.Add(this.label182);
            this.groupBox80.Controls.Add(this.label202);
            this.groupBox80.Controls.Add(this.label204);
            this.groupBox80.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox80.Location = new System.Drawing.Point(15, 14);
            this.groupBox80.Name = "groupBox80";
            this.groupBox80.Size = new System.Drawing.Size(699, 128);
            this.groupBox80.TabIndex = 37;
            this.groupBox80.TabStop = false;
            this.groupBox80.Text = "Device Status";
            // 
            // txtAX2Disable
            // 
            this.txtAX2Disable.BackColor = System.Drawing.Color.Maroon;
            this.txtAX2Disable.Location = new System.Drawing.Point(183, 85);
            this.txtAX2Disable.Name = "txtAX2Disable";
            this.txtAX2Disable.Size = new System.Drawing.Size(27, 26);
            this.txtAX2Disable.TabIndex = 63;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.Location = new System.Drawing.Point(91, 93);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(89, 14);
            this.label136.TabIndex = 62;
            this.label136.Text = "Servo Disable";
            // 
            // label137
            // 
            this.label137.BackColor = System.Drawing.Color.Maroon;
            this.label137.Location = new System.Drawing.Point(537, 81);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(27, 26);
            this.label137.TabIndex = 61;
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.Location = new System.Drawing.Point(443, 90);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(93, 14);
            this.label139.TabIndex = 60;
            this.label139.Text = "Servo In Error";
            // 
            // label142
            // 
            this.label142.BackColor = System.Drawing.Color.Maroon;
            this.label142.Location = new System.Drawing.Point(537, 31);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(27, 26);
            this.label142.TabIndex = 48;
            // 
            // label143
            // 
            this.label143.BackColor = System.Drawing.Color.Maroon;
            this.label143.Location = new System.Drawing.Point(363, 81);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(27, 26);
            this.label143.TabIndex = 47;
            // 
            // label159
            // 
            this.label159.BackColor = System.Drawing.Color.Maroon;
            this.label159.Location = new System.Drawing.Point(363, 28);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(27, 26);
            this.label159.TabIndex = 46;
            // 
            // txtAX2Enable
            // 
            this.txtAX2Enable.BackColor = System.Drawing.Color.Maroon;
            this.txtAX2Enable.Location = new System.Drawing.Point(183, 28);
            this.txtAX2Enable.Name = "txtAX2Enable";
            this.txtAX2Enable.Size = new System.Drawing.Size(27, 26);
            this.txtAX2Enable.TabIndex = 45;
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label179.Location = new System.Drawing.Point(263, 90);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(98, 14);
            this.label179.TabIndex = 43;
            this.label179.Text = "Servo Running";
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label182.Location = new System.Drawing.Point(455, 40);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(81, 14);
            this.label182.TabIndex = 41;
            this.label182.Text = "Servo Home";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label202.Location = new System.Drawing.Point(278, 36);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(84, 14);
            this.label202.TabIndex = 39;
            this.label202.Text = "Servo Ready";
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label204.Location = new System.Drawing.Point(92, 36);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(86, 14);
            this.label204.TabIndex = 37;
            this.label204.Text = "Servo Enable";
            // 
            // AxisZ1
            // 
            this.AxisZ1.BackColor = System.Drawing.Color.LightGray;
            this.AxisZ1.Controls.Add(this.groupBox67);
            this.AxisZ1.Location = new System.Drawing.Point(4, 29);
            this.AxisZ1.Name = "AxisZ1";
            this.AxisZ1.Size = new System.Drawing.Size(1371, 542);
            this.AxisZ1.TabIndex = 2;
            this.AxisZ1.Text = "Z1 - Axis";
            // 
            // groupBox67
            // 
            this.groupBox67.BackColor = System.Drawing.Color.White;
            this.groupBox67.Controls.Add(this.groupBox68);
            this.groupBox67.Controls.Add(this.groupBox69);
            this.groupBox67.Controls.Add(this.groupBox70);
            this.groupBox67.Controls.Add(this.groupBox71);
            this.groupBox67.Controls.Add(this.groupBox72);
            this.groupBox67.Controls.Add(this.groupBox73);
            this.groupBox67.Controls.Add(this.groupBox74);
            this.groupBox67.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox67.Location = new System.Drawing.Point(239, 47);
            this.groupBox67.Name = "groupBox67";
            this.groupBox67.Size = new System.Drawing.Size(1116, 485);
            this.groupBox67.TabIndex = 40;
            this.groupBox67.TabStop = false;
            // 
            // groupBox68
            // 
            this.groupBox68.Controls.Add(this.Btn_ScrewServo_Enable_Z1);
            this.groupBox68.Controls.Add(this.btnScrewServoZ1ClearErr);
            this.groupBox68.Controls.Add(this.Btn_ScrewServo_disable_Z1);
            this.groupBox68.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox68.Location = new System.Drawing.Point(51, 149);
            this.groupBox68.Name = "groupBox68";
            this.groupBox68.Size = new System.Drawing.Size(177, 168);
            this.groupBox68.TabIndex = 75;
            this.groupBox68.TabStop = false;
            this.groupBox68.Text = "Device Control";
            // 
            // Btn_ScrewServo_Enable_Z1
            // 
            this.Btn_ScrewServo_Enable_Z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_Enable_Z1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_Enable_Z1.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_Enable_Z1.Location = new System.Drawing.Point(11, 26);
            this.Btn_ScrewServo_Enable_Z1.Name = "Btn_ScrewServo_Enable_Z1";
            this.Btn_ScrewServo_Enable_Z1.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_Enable_Z1.TabIndex = 71;
            this.Btn_ScrewServo_Enable_Z1.Text = "Servo Enable";
            this.Btn_ScrewServo_Enable_Z1.UseVisualStyleBackColor = false;
            // 
            // btnScrewServoZ1ClearErr
            // 
            this.btnScrewServoZ1ClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewServoZ1ClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewServoZ1ClearErr.ForeColor = System.Drawing.Color.White;
            this.btnScrewServoZ1ClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnScrewServoZ1ClearErr.Name = "btnScrewServoZ1ClearErr";
            this.btnScrewServoZ1ClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnScrewServoZ1ClearErr.TabIndex = 71;
            this.btnScrewServoZ1ClearErr.Text = "Servo Clear Error";
            this.btnScrewServoZ1ClearErr.UseVisualStyleBackColor = false;
            // 
            // Btn_ScrewServo_disable_Z1
            // 
            this.Btn_ScrewServo_disable_Z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_disable_Z1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_disable_Z1.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_disable_Z1.Location = new System.Drawing.Point(11, 70);
            this.Btn_ScrewServo_disable_Z1.Name = "Btn_ScrewServo_disable_Z1";
            this.Btn_ScrewServo_disable_Z1.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_disable_Z1.TabIndex = 71;
            this.Btn_ScrewServo_disable_Z1.Text = "Servo Disable";
            this.Btn_ScrewServo_disable_Z1.UseVisualStyleBackColor = false;
            // 
            // groupBox69
            // 
            this.groupBox69.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox69.Controls.Add(this.lbl_Z1ScrewSV_TP);
            this.groupBox69.Controls.Add(this.label291);
            this.groupBox69.Controls.Add(this.label292);
            this.groupBox69.Controls.Add(this.lbl_Z1ScrewServo_ActualPosition);
            this.groupBox69.Controls.Add(this.label294);
            this.groupBox69.Controls.Add(this.label295);
            this.groupBox69.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox69.Location = new System.Drawing.Point(756, 14);
            this.groupBox69.Name = "groupBox69";
            this.groupBox69.Size = new System.Drawing.Size(342, 128);
            this.groupBox69.TabIndex = 74;
            this.groupBox69.TabStop = false;
            this.groupBox69.Text = "Live Values";
            // 
            // lbl_Z1ScrewSV_TP
            // 
            this.lbl_Z1ScrewSV_TP.AutoSize = true;
            this.lbl_Z1ScrewSV_TP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Z1ScrewSV_TP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Z1ScrewSV_TP.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Z1ScrewSV_TP.Location = new System.Drawing.Point(184, 81);
            this.lbl_Z1ScrewSV_TP.Name = "lbl_Z1ScrewSV_TP";
            this.lbl_Z1ScrewSV_TP.Size = new System.Drawing.Size(18, 16);
            this.lbl_Z1ScrewSV_TP.TabIndex = 80;
            this.lbl_Z1ScrewSV_TP.Text = "0";
            this.lbl_Z1ScrewSV_TP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label291
            // 
            this.label291.AutoSize = true;
            this.label291.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label291.Location = new System.Drawing.Point(28, 83);
            this.label291.Name = "label291";
            this.label291.Size = new System.Drawing.Size(140, 14);
            this.label291.TabIndex = 79;
            this.label291.Text = "Servo Target Position";
            // 
            // label292
            // 
            this.label292.AutoSize = true;
            this.label292.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label292.Location = new System.Drawing.Point(291, 83);
            this.label292.Name = "label292";
            this.label292.Size = new System.Drawing.Size(37, 14);
            this.label292.TabIndex = 78;
            this.label292.Text = "(mm)";
            // 
            // lbl_Z1ScrewServo_ActualPosition
            // 
            this.lbl_Z1ScrewServo_ActualPosition.AutoSize = true;
            this.lbl_Z1ScrewServo_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Z1ScrewServo_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Z1ScrewServo_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Z1ScrewServo_ActualPosition.Location = new System.Drawing.Point(184, 42);
            this.lbl_Z1ScrewServo_ActualPosition.Name = "lbl_Z1ScrewServo_ActualPosition";
            this.lbl_Z1ScrewServo_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_Z1ScrewServo_ActualPosition.TabIndex = 53;
            this.lbl_Z1ScrewServo_ActualPosition.Text = "0";
            this.lbl_Z1ScrewServo_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label294
            // 
            this.label294.AutoSize = true;
            this.label294.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label294.Location = new System.Drawing.Point(291, 45);
            this.label294.Name = "label294";
            this.label294.Size = new System.Drawing.Size(37, 14);
            this.label294.TabIndex = 75;
            this.label294.Text = "(mm)";
            // 
            // label295
            // 
            this.label295.AutoSize = true;
            this.label295.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label295.Location = new System.Drawing.Point(28, 45);
            this.label295.Name = "label295";
            this.label295.Size = new System.Drawing.Size(139, 14);
            this.label295.TabIndex = 52;
            this.label295.Text = "Servo Actual Position";
            // 
            // groupBox70
            // 
            this.groupBox70.Controls.Add(this.button39);
            this.groupBox70.Controls.Add(this.button40);
            this.groupBox70.Controls.Add(this.textBox45);
            this.groupBox70.Controls.Add(this.textBox48);
            this.groupBox70.Controls.Add(this.textBox50);
            this.groupBox70.Controls.Add(this.label296);
            this.groupBox70.Controls.Add(this.label297);
            this.groupBox70.Controls.Add(this.textBox51);
            this.groupBox70.Controls.Add(this.label298);
            this.groupBox70.Controls.Add(this.textBox52);
            this.groupBox70.Controls.Add(this.label299);
            this.groupBox70.Controls.Add(this.label300);
            this.groupBox70.Controls.Add(this.label301);
            this.groupBox70.Controls.Add(this.label302);
            this.groupBox70.Controls.Add(this.label303);
            this.groupBox70.Controls.Add(this.label304);
            this.groupBox70.Controls.Add(this.label305);
            this.groupBox70.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox70.Location = new System.Drawing.Point(141, 326);
            this.groupBox70.Name = "groupBox70";
            this.groupBox70.Size = new System.Drawing.Size(781, 149);
            this.groupBox70.TabIndex = 73;
            this.groupBox70.TabStop = false;
            this.groupBox70.Text = "Point To Point Control";
            // 
            // button39
            // 
            this.button39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button39.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button39.ForeColor = System.Drawing.Color.White;
            this.button39.Location = new System.Drawing.Point(399, 103);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(83, 38);
            this.button39.TabIndex = 71;
            this.button39.Text = "Stop";
            this.button39.UseVisualStyleBackColor = false;
            // 
            // button40
            // 
            this.button40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button40.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button40.ForeColor = System.Drawing.Color.White;
            this.button40.Location = new System.Drawing.Point(203, 103);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(83, 38);
            this.button40.TabIndex = 70;
            this.button40.Text = "Move";
            this.button40.UseVisualStyleBackColor = false;
            // 
            // textBox45
            // 
            this.textBox45.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox45.Location = new System.Drawing.Point(603, 28);
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new System.Drawing.Size(67, 26);
            this.textBox45.TabIndex = 61;
            // 
            // textBox48
            // 
            this.textBox48.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox48.Location = new System.Drawing.Point(336, 65);
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new System.Drawing.Size(67, 26);
            this.textBox48.TabIndex = 61;
            // 
            // textBox50
            // 
            this.textBox50.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox50.Location = new System.Drawing.Point(336, 28);
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new System.Drawing.Size(67, 26);
            this.textBox50.TabIndex = 61;
            // 
            // label296
            // 
            this.label296.AutoSize = true;
            this.label296.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label296.Location = new System.Drawing.Point(21, 80);
            this.label296.Name = "label296";
            this.label296.Size = new System.Drawing.Size(84, 14);
            this.label296.TabIndex = 37;
            this.label296.Text = "End Position";
            // 
            // label297
            // 
            this.label297.AutoSize = true;
            this.label297.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label297.Location = new System.Drawing.Point(14, 40);
            this.label297.Name = "label297";
            this.label297.Size = new System.Drawing.Size(93, 14);
            this.label297.TabIndex = 37;
            this.label297.Text = "Start Position";
            // 
            // textBox51
            // 
            this.textBox51.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox51.Location = new System.Drawing.Point(105, 71);
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new System.Drawing.Size(67, 26);
            this.textBox51.TabIndex = 59;
            // 
            // label298
            // 
            this.label298.AutoSize = true;
            this.label298.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label298.Location = new System.Drawing.Point(539, 40);
            this.label298.Name = "label298";
            this.label298.Size = new System.Drawing.Size(62, 14);
            this.label298.TabIndex = 60;
            this.label298.Text = "Iteration";
            // 
            // textBox52
            // 
            this.textBox52.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox52.Location = new System.Drawing.Point(105, 32);
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new System.Drawing.Size(67, 26);
            this.textBox52.TabIndex = 59;
            // 
            // label299
            // 
            this.label299.AutoSize = true;
            this.label299.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label299.Location = new System.Drawing.Point(297, 76);
            this.label299.Name = "label299";
            this.label299.Size = new System.Drawing.Size(35, 14);
            this.label299.TabIndex = 60;
            this.label299.Text = "Wait";
            // 
            // label300
            // 
            this.label300.AutoSize = true;
            this.label300.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label300.Location = new System.Drawing.Point(179, 80);
            this.label300.Name = "label300";
            this.label300.Size = new System.Drawing.Size(37, 14);
            this.label300.TabIndex = 66;
            this.label300.Text = "(mm)";
            // 
            // label301
            // 
            this.label301.AutoSize = true;
            this.label301.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label301.Location = new System.Drawing.Point(676, 40);
            this.label301.Name = "label301";
            this.label301.Size = new System.Drawing.Size(39, 14);
            this.label301.TabIndex = 67;
            this.label301.Text = "count";
            // 
            // label302
            // 
            this.label302.AutoSize = true;
            this.label302.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label302.Location = new System.Drawing.Point(287, 40);
            this.label302.Name = "label302";
            this.label302.Size = new System.Drawing.Size(45, 14);
            this.label302.TabIndex = 60;
            this.label302.Text = "Speed";
            // 
            // label303
            // 
            this.label303.AutoSize = true;
            this.label303.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label303.Location = new System.Drawing.Point(410, 76);
            this.label303.Name = "label303";
            this.label303.Size = new System.Drawing.Size(25, 14);
            this.label303.TabIndex = 67;
            this.label303.Text = "sec";
            // 
            // label304
            // 
            this.label304.AutoSize = true;
            this.label304.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label304.Location = new System.Drawing.Point(179, 40);
            this.label304.Name = "label304";
            this.label304.Size = new System.Drawing.Size(37, 14);
            this.label304.TabIndex = 66;
            this.label304.Text = "(mm)";
            // 
            // label305
            // 
            this.label305.AutoSize = true;
            this.label305.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label305.Location = new System.Drawing.Point(410, 40);
            this.label305.Name = "label305";
            this.label305.Size = new System.Drawing.Size(47, 14);
            this.label305.TabIndex = 67;
            this.label305.Text = "(mm/s)";
            // 
            // groupBox71
            // 
            this.groupBox71.BackColor = System.Drawing.Color.White;
            this.groupBox71.Controls.Add(this.comboBox4);
            this.groupBox71.Controls.Add(this.label306);
            this.groupBox71.Controls.Add(this.textBox53);
            this.groupBox71.Controls.Add(this.label307);
            this.groupBox71.Controls.Add(this.label308);
            this.groupBox71.Controls.Add(this.button41);
            this.groupBox71.Controls.Add(this.button42);
            this.groupBox71.Controls.Add(this.label309);
            this.groupBox71.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox71.Location = new System.Drawing.Point(815, 153);
            this.groupBox71.Name = "groupBox71";
            this.groupBox71.Size = new System.Drawing.Size(249, 165);
            this.groupBox71.TabIndex = 72;
            this.groupBox71.TabStop = false;
            this.groupBox71.Text = "Jog Control";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox4.Location = new System.Drawing.Point(105, 64);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(67, 26);
            this.comboBox4.TabIndex = 78;
            this.comboBox4.Visible = false;
            // 
            // label306
            // 
            this.label306.AutoSize = true;
            this.label306.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label306.Location = new System.Drawing.Point(176, 41);
            this.label306.Name = "label306";
            this.label306.Size = new System.Drawing.Size(37, 14);
            this.label306.TabIndex = 77;
            this.label306.Text = "(mm)";
            this.label306.Visible = false;
            // 
            // textBox53
            // 
            this.textBox53.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox53.Location = new System.Drawing.Point(105, 32);
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new System.Drawing.Size(67, 26);
            this.textBox53.TabIndex = 76;
            this.textBox53.Visible = false;
            // 
            // label307
            // 
            this.label307.AutoSize = true;
            this.label307.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label307.Location = new System.Drawing.Point(20, 40);
            this.label307.Name = "label307";
            this.label307.Size = new System.Drawing.Size(83, 14);
            this.label307.TabIndex = 75;
            this.label307.Text = "Jog Position";
            this.label307.Visible = false;
            // 
            // label308
            // 
            this.label308.AutoSize = true;
            this.label308.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label308.Location = new System.Drawing.Point(172, 71);
            this.label308.Name = "label308";
            this.label308.Size = new System.Drawing.Size(47, 14);
            this.label308.TabIndex = 73;
            this.label308.Text = "(mm/s)";
            this.label308.Visible = false;
            // 
            // button41
            // 
            this.button41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button41.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button41.ForeColor = System.Drawing.Color.White;
            this.button41.Location = new System.Drawing.Point(123, 107);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(83, 38);
            this.button41.TabIndex = 74;
            this.button41.Text = "Jog -";
            this.button41.UseVisualStyleBackColor = false;
            // 
            // button42
            // 
            this.button42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button42.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button42.ForeColor = System.Drawing.Color.White;
            this.button42.Location = new System.Drawing.Point(24, 107);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(83, 38);
            this.button42.TabIndex = 73;
            this.button42.Text = "Jog +";
            this.button42.UseVisualStyleBackColor = false;
            // 
            // label309
            // 
            this.label309.AutoSize = true;
            this.label309.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label309.Location = new System.Drawing.Point(20, 72);
            this.label309.Name = "label309";
            this.label309.Size = new System.Drawing.Size(81, 14);
            this.label309.TabIndex = 37;
            this.label309.Text = "Jog Velocity";
            this.label309.Visible = false;
            // 
            // groupBox72
            // 
            this.groupBox72.BackColor = System.Drawing.Color.White;
            this.groupBox72.Controls.Add(this.button43);
            this.groupBox72.Controls.Add(this.label310);
            this.groupBox72.Controls.Add(this.btnScrewHome_Z1);
            this.groupBox72.Controls.Add(this.textBox54);
            this.groupBox72.Controls.Add(this.label311);
            this.groupBox72.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox72.Location = new System.Drawing.Point(531, 153);
            this.groupBox72.Name = "groupBox72";
            this.groupBox72.Size = new System.Drawing.Size(249, 165);
            this.groupBox72.TabIndex = 71;
            this.groupBox72.TabStop = false;
            this.groupBox72.Text = "Homing Control";
            // 
            // button43
            // 
            this.button43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button43.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button43.ForeColor = System.Drawing.Color.White;
            this.button43.Location = new System.Drawing.Point(132, 105);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(83, 38);
            this.button43.TabIndex = 72;
            this.button43.Text = "Stop";
            this.button43.UseVisualStyleBackColor = false;
            // 
            // label310
            // 
            this.label310.AutoSize = true;
            this.label310.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label310.Location = new System.Drawing.Point(179, 55);
            this.label310.Name = "label310";
            this.label310.Size = new System.Drawing.Size(47, 14);
            this.label310.TabIndex = 72;
            this.label310.Text = "(mm/s)";
            // 
            // btnScrewHome_Z1
            // 
            this.btnScrewHome_Z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewHome_Z1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewHome_Z1.ForeColor = System.Drawing.Color.White;
            this.btnScrewHome_Z1.Location = new System.Drawing.Point(19, 105);
            this.btnScrewHome_Z1.Name = "btnScrewHome_Z1";
            this.btnScrewHome_Z1.Size = new System.Drawing.Size(83, 38);
            this.btnScrewHome_Z1.TabIndex = 72;
            this.btnScrewHome_Z1.Text = "Home";
            this.btnScrewHome_Z1.UseVisualStyleBackColor = false;
            // 
            // textBox54
            // 
            this.textBox54.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox54.Location = new System.Drawing.Point(108, 47);
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new System.Drawing.Size(67, 26);
            this.textBox54.TabIndex = 59;
            // 
            // label311
            // 
            this.label311.AutoSize = true;
            this.label311.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label311.Location = new System.Drawing.Point(9, 55);
            this.label311.Name = "label311";
            this.label311.Size = new System.Drawing.Size(94, 14);
            this.label311.TabIndex = 37;
            this.label311.Text = "Home Velocity";
            // 
            // groupBox73
            // 
            this.groupBox73.BackColor = System.Drawing.Color.White;
            this.groupBox73.Controls.Add(this.btn_Z1ScrewMove_stop);
            this.groupBox73.Controls.Add(this.btnScrewSVMove_Z1);
            this.groupBox73.Controls.Add(this.label322);
            this.groupBox73.Controls.Add(this.label323);
            this.groupBox73.Controls.Add(this.lbl_Z1ScrewSV_TargetSpeed);
            this.groupBox73.Controls.Add(this.label324);
            this.groupBox73.Controls.Add(this.lbl_Z1ScrewSV_TargetPosition);
            this.groupBox73.Controls.Add(this.label325);
            this.groupBox73.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox73.Location = new System.Drawing.Point(271, 149);
            this.groupBox73.Name = "groupBox73";
            this.groupBox73.Size = new System.Drawing.Size(219, 168);
            this.groupBox73.TabIndex = 56;
            this.groupBox73.TabStop = false;
            this.groupBox73.Text = "Motion Control";
            // 
            // btn_Z1ScrewMove_stop
            // 
            this.btn_Z1ScrewMove_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_Z1ScrewMove_stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Z1ScrewMove_stop.ForeColor = System.Drawing.Color.White;
            this.btn_Z1ScrewMove_stop.Location = new System.Drawing.Point(119, 107);
            this.btn_Z1ScrewMove_stop.Name = "btn_Z1ScrewMove_stop";
            this.btn_Z1ScrewMove_stop.Size = new System.Drawing.Size(83, 38);
            this.btn_Z1ScrewMove_stop.TabIndex = 73;
            this.btn_Z1ScrewMove_stop.Text = "Stop";
            this.btn_Z1ScrewMove_stop.UseVisualStyleBackColor = false;
            // 
            // btnScrewSVMove_Z1
            // 
            this.btnScrewSVMove_Z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewSVMove_Z1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewSVMove_Z1.ForeColor = System.Drawing.Color.White;
            this.btnScrewSVMove_Z1.Location = new System.Drawing.Point(18, 107);
            this.btnScrewSVMove_Z1.Name = "btnScrewSVMove_Z1";
            this.btnScrewSVMove_Z1.Size = new System.Drawing.Size(83, 38);
            this.btnScrewSVMove_Z1.TabIndex = 70;
            this.btnScrewSVMove_Z1.Text = "Move";
            this.btnScrewSVMove_Z1.UseVisualStyleBackColor = false;
            // 
            // label322
            // 
            this.label322.AutoSize = true;
            this.label322.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label322.Location = new System.Drawing.Point(159, 79);
            this.label322.Name = "label322";
            this.label322.Size = new System.Drawing.Size(47, 14);
            this.label322.TabIndex = 67;
            this.label322.Text = "(mm/s)";
            // 
            // label323
            // 
            this.label323.AutoSize = true;
            this.label323.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label323.Location = new System.Drawing.Point(159, 37);
            this.label323.Name = "label323";
            this.label323.Size = new System.Drawing.Size(37, 14);
            this.label323.TabIndex = 66;
            this.label323.Text = "(mm)";
            // 
            // lbl_Z1ScrewSV_TargetSpeed
            // 
            this.lbl_Z1ScrewSV_TargetSpeed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Z1ScrewSV_TargetSpeed.Location = new System.Drawing.Point(85, 66);
            this.lbl_Z1ScrewSV_TargetSpeed.Name = "lbl_Z1ScrewSV_TargetSpeed";
            this.lbl_Z1ScrewSV_TargetSpeed.Size = new System.Drawing.Size(67, 26);
            this.lbl_Z1ScrewSV_TargetSpeed.TabIndex = 61;
            // 
            // label324
            // 
            this.label324.AutoSize = true;
            this.label324.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label324.Location = new System.Drawing.Point(23, 73);
            this.label324.Name = "label324";
            this.label324.Size = new System.Drawing.Size(45, 14);
            this.label324.TabIndex = 60;
            this.label324.Text = "Speed";
            // 
            // lbl_Z1ScrewSV_TargetPosition
            // 
            this.lbl_Z1ScrewSV_TargetPosition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Z1ScrewSV_TargetPosition.Location = new System.Drawing.Point(85, 29);
            this.lbl_Z1ScrewSV_TargetPosition.Name = "lbl_Z1ScrewSV_TargetPosition";
            this.lbl_Z1ScrewSV_TargetPosition.Size = new System.Drawing.Size(67, 26);
            this.lbl_Z1ScrewSV_TargetPosition.TabIndex = 59;
            // 
            // label325
            // 
            this.label325.AutoSize = true;
            this.label325.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label325.Location = new System.Drawing.Point(23, 36);
            this.label325.Name = "label325";
            this.label325.Size = new System.Drawing.Size(57, 14);
            this.label325.TabIndex = 37;
            this.label325.Text = "Position";
            // 
            // groupBox74
            // 
            this.groupBox74.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox74.Controls.Add(this.lblScrewServoZ1disable);
            this.groupBox74.Controls.Add(this.label327);
            this.groupBox74.Controls.Add(this.lblScrewServoZ1Error);
            this.groupBox74.Controls.Add(this.label329);
            this.groupBox74.Controls.Add(this.lblScrewServoZ1Positive_limit);
            this.groupBox74.Controls.Add(this.label331);
            this.groupBox74.Controls.Add(this.lblScrewServoZ1Home);
            this.groupBox74.Controls.Add(this.lblScrewServoZ1Running);
            this.groupBox74.Controls.Add(this.lblScrewServoZ1Ready);
            this.groupBox74.Controls.Add(this.lblScrewServoZ1Negative_limit);
            this.groupBox74.Controls.Add(this.lblScrewServoZ1Enable);
            this.groupBox74.Controls.Add(this.label337);
            this.groupBox74.Controls.Add(this.label338);
            this.groupBox74.Controls.Add(this.label339);
            this.groupBox74.Controls.Add(this.label340);
            this.groupBox74.Controls.Add(this.label341);
            this.groupBox74.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox74.Location = new System.Drawing.Point(17, 14);
            this.groupBox74.Name = "groupBox74";
            this.groupBox74.Size = new System.Drawing.Size(715, 128);
            this.groupBox74.TabIndex = 37;
            this.groupBox74.TabStop = false;
            this.groupBox74.Text = "Device Status";
            // 
            // lblScrewServoZ1disable
            // 
            this.lblScrewServoZ1disable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ1disable.Location = new System.Drawing.Point(111, 87);
            this.lblScrewServoZ1disable.Name = "lblScrewServoZ1disable";
            this.lblScrewServoZ1disable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ1disable.TabIndex = 67;
            // 
            // label327
            // 
            this.label327.AutoSize = true;
            this.label327.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label327.Location = new System.Drawing.Point(20, 94);
            this.label327.Name = "label327";
            this.label327.Size = new System.Drawing.Size(89, 14);
            this.label327.TabIndex = 66;
            this.label327.Text = "Servo Disable";
            // 
            // lblScrewServoZ1Error
            // 
            this.lblScrewServoZ1Error.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ1Error.Location = new System.Drawing.Point(467, 87);
            this.lblScrewServoZ1Error.Name = "lblScrewServoZ1Error";
            this.lblScrewServoZ1Error.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ1Error.TabIndex = 61;
            // 
            // label329
            // 
            this.label329.AutoSize = true;
            this.label329.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label329.Location = new System.Drawing.Point(373, 94);
            this.label329.Name = "label329";
            this.label329.Size = new System.Drawing.Size(93, 14);
            this.label329.TabIndex = 60;
            this.label329.Text = "Servo In Error";
            // 
            // lblScrewServoZ1Positive_limit
            // 
            this.lblScrewServoZ1Positive_limit.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ1Positive_limit.Location = new System.Drawing.Point(661, 87);
            this.lblScrewServoZ1Positive_limit.Name = "lblScrewServoZ1Positive_limit";
            this.lblScrewServoZ1Positive_limit.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ1Positive_limit.TabIndex = 59;
            // 
            // label331
            // 
            this.label331.AutoSize = true;
            this.label331.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label331.Location = new System.Drawing.Point(568, 94);
            this.label331.Name = "label331";
            this.label331.Size = new System.Drawing.Size(89, 14);
            this.label331.TabIndex = 56;
            this.label331.Text = "Positive Limit";
            // 
            // lblScrewServoZ1Home
            // 
            this.lblScrewServoZ1Home.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ1Home.Location = new System.Drawing.Point(467, 36);
            this.lblScrewServoZ1Home.Name = "lblScrewServoZ1Home";
            this.lblScrewServoZ1Home.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ1Home.TabIndex = 48;
            // 
            // lblScrewServoZ1Running
            // 
            this.lblScrewServoZ1Running.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ1Running.Location = new System.Drawing.Point(291, 87);
            this.lblScrewServoZ1Running.Name = "lblScrewServoZ1Running";
            this.lblScrewServoZ1Running.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ1Running.TabIndex = 47;
            // 
            // lblScrewServoZ1Ready
            // 
            this.lblScrewServoZ1Ready.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ1Ready.Location = new System.Drawing.Point(291, 33);
            this.lblScrewServoZ1Ready.Name = "lblScrewServoZ1Ready";
            this.lblScrewServoZ1Ready.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ1Ready.TabIndex = 46;
            // 
            // lblScrewServoZ1Negative_limit
            // 
            this.lblScrewServoZ1Negative_limit.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ1Negative_limit.Location = new System.Drawing.Point(661, 33);
            this.lblScrewServoZ1Negative_limit.Name = "lblScrewServoZ1Negative_limit";
            this.lblScrewServoZ1Negative_limit.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ1Negative_limit.TabIndex = 45;
            // 
            // lblScrewServoZ1Enable
            // 
            this.lblScrewServoZ1Enable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ1Enable.Location = new System.Drawing.Point(111, 33);
            this.lblScrewServoZ1Enable.Name = "lblScrewServoZ1Enable";
            this.lblScrewServoZ1Enable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ1Enable.TabIndex = 45;
            // 
            // label337
            // 
            this.label337.AutoSize = true;
            this.label337.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label337.Location = new System.Drawing.Point(193, 94);
            this.label337.Name = "label337";
            this.label337.Size = new System.Drawing.Size(98, 14);
            this.label337.TabIndex = 43;
            this.label337.Text = "Servo Running";
            // 
            // label338
            // 
            this.label338.AutoSize = true;
            this.label338.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label338.Location = new System.Drawing.Point(385, 44);
            this.label338.Name = "label338";
            this.label338.Size = new System.Drawing.Size(81, 14);
            this.label338.TabIndex = 41;
            this.label338.Text = "Servo Home";
            // 
            // label339
            // 
            this.label339.AutoSize = true;
            this.label339.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label339.Location = new System.Drawing.Point(562, 41);
            this.label339.Name = "label339";
            this.label339.Size = new System.Drawing.Size(94, 14);
            this.label339.TabIndex = 37;
            this.label339.Text = "Negative Limit";
            // 
            // label340
            // 
            this.label340.AutoSize = true;
            this.label340.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label340.Location = new System.Drawing.Point(207, 41);
            this.label340.Name = "label340";
            this.label340.Size = new System.Drawing.Size(84, 14);
            this.label340.TabIndex = 39;
            this.label340.Text = "Servo Ready";
            // 
            // label341
            // 
            this.label341.AutoSize = true;
            this.label341.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label341.Location = new System.Drawing.Point(20, 41);
            this.label341.Name = "label341";
            this.label341.Size = new System.Drawing.Size(86, 14);
            this.label341.TabIndex = 37;
            this.label341.Text = "Servo Enable";
            // 
            // AxisZ2
            // 
            this.AxisZ2.BackColor = System.Drawing.Color.LightGray;
            this.AxisZ2.Controls.Add(this.groupBox75);
            this.AxisZ2.Location = new System.Drawing.Point(4, 29);
            this.AxisZ2.Name = "AxisZ2";
            this.AxisZ2.Size = new System.Drawing.Size(1371, 542);
            this.AxisZ2.TabIndex = 4;
            this.AxisZ2.Text = "Z2 - Axis";
            // 
            // groupBox75
            // 
            this.groupBox75.BackColor = System.Drawing.Color.White;
            this.groupBox75.Controls.Add(this.groupBox76);
            this.groupBox75.Controls.Add(this.groupBox77);
            this.groupBox75.Controls.Add(this.groupBox78);
            this.groupBox75.Controls.Add(this.groupBox83);
            this.groupBox75.Controls.Add(this.groupBox86);
            this.groupBox75.Controls.Add(this.groupBox88);
            this.groupBox75.Controls.Add(this.groupBox93);
            this.groupBox75.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox75.Location = new System.Drawing.Point(239, 47);
            this.groupBox75.Name = "groupBox75";
            this.groupBox75.Size = new System.Drawing.Size(1116, 485);
            this.groupBox75.TabIndex = 41;
            this.groupBox75.TabStop = false;
            // 
            // groupBox76
            // 
            this.groupBox76.Controls.Add(this.Btn_ScrewServo_Enable_Z2);
            this.groupBox76.Controls.Add(this.btnScrewServoZ2ClearErr);
            this.groupBox76.Controls.Add(this.Btn_ScrewServo_disable_Z2);
            this.groupBox76.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox76.Location = new System.Drawing.Point(51, 149);
            this.groupBox76.Name = "groupBox76";
            this.groupBox76.Size = new System.Drawing.Size(177, 168);
            this.groupBox76.TabIndex = 75;
            this.groupBox76.TabStop = false;
            this.groupBox76.Text = "Device Control";
            // 
            // Btn_ScrewServo_Enable_Z2
            // 
            this.Btn_ScrewServo_Enable_Z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_Enable_Z2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_Enable_Z2.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_Enable_Z2.Location = new System.Drawing.Point(11, 26);
            this.Btn_ScrewServo_Enable_Z2.Name = "Btn_ScrewServo_Enable_Z2";
            this.Btn_ScrewServo_Enable_Z2.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_Enable_Z2.TabIndex = 71;
            this.Btn_ScrewServo_Enable_Z2.Text = "Servo Enable";
            this.Btn_ScrewServo_Enable_Z2.UseVisualStyleBackColor = false;
            // 
            // btnScrewServoZ2ClearErr
            // 
            this.btnScrewServoZ2ClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewServoZ2ClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewServoZ2ClearErr.ForeColor = System.Drawing.Color.White;
            this.btnScrewServoZ2ClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnScrewServoZ2ClearErr.Name = "btnScrewServoZ2ClearErr";
            this.btnScrewServoZ2ClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnScrewServoZ2ClearErr.TabIndex = 71;
            this.btnScrewServoZ2ClearErr.Text = "Servo Clear Error";
            this.btnScrewServoZ2ClearErr.UseVisualStyleBackColor = false;
            // 
            // Btn_ScrewServo_disable_Z2
            // 
            this.Btn_ScrewServo_disable_Z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Btn_ScrewServo_disable_Z2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ScrewServo_disable_Z2.ForeColor = System.Drawing.Color.White;
            this.Btn_ScrewServo_disable_Z2.Location = new System.Drawing.Point(11, 70);
            this.Btn_ScrewServo_disable_Z2.Name = "Btn_ScrewServo_disable_Z2";
            this.Btn_ScrewServo_disable_Z2.Size = new System.Drawing.Size(147, 38);
            this.Btn_ScrewServo_disable_Z2.TabIndex = 71;
            this.Btn_ScrewServo_disable_Z2.Text = "Servo Disable";
            this.Btn_ScrewServo_disable_Z2.UseVisualStyleBackColor = false;
            // 
            // groupBox77
            // 
            this.groupBox77.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox77.Controls.Add(this.lbl_Z2ScrewSV_TP);
            this.groupBox77.Controls.Add(this.label344);
            this.groupBox77.Controls.Add(this.label345);
            this.groupBox77.Controls.Add(this.lbl_Z2Servo_ActualPosition);
            this.groupBox77.Controls.Add(this.label347);
            this.groupBox77.Controls.Add(this.label348);
            this.groupBox77.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox77.Location = new System.Drawing.Point(756, 14);
            this.groupBox77.Name = "groupBox77";
            this.groupBox77.Size = new System.Drawing.Size(342, 128);
            this.groupBox77.TabIndex = 74;
            this.groupBox77.TabStop = false;
            this.groupBox77.Text = "Live Values";
            // 
            // lbl_Z2ScrewSV_TP
            // 
            this.lbl_Z2ScrewSV_TP.AutoSize = true;
            this.lbl_Z2ScrewSV_TP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Z2ScrewSV_TP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Z2ScrewSV_TP.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Z2ScrewSV_TP.Location = new System.Drawing.Point(184, 81);
            this.lbl_Z2ScrewSV_TP.Name = "lbl_Z2ScrewSV_TP";
            this.lbl_Z2ScrewSV_TP.Size = new System.Drawing.Size(18, 16);
            this.lbl_Z2ScrewSV_TP.TabIndex = 80;
            this.lbl_Z2ScrewSV_TP.Text = "0";
            this.lbl_Z2ScrewSV_TP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label344
            // 
            this.label344.AutoSize = true;
            this.label344.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label344.Location = new System.Drawing.Point(28, 83);
            this.label344.Name = "label344";
            this.label344.Size = new System.Drawing.Size(140, 14);
            this.label344.TabIndex = 79;
            this.label344.Text = "Servo Target Position";
            // 
            // label345
            // 
            this.label345.AutoSize = true;
            this.label345.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label345.Location = new System.Drawing.Point(291, 83);
            this.label345.Name = "label345";
            this.label345.Size = new System.Drawing.Size(37, 14);
            this.label345.TabIndex = 78;
            this.label345.Text = "(mm)";
            // 
            // lbl_Z2Servo_ActualPosition
            // 
            this.lbl_Z2Servo_ActualPosition.AutoSize = true;
            this.lbl_Z2Servo_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Z2Servo_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Z2Servo_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Z2Servo_ActualPosition.Location = new System.Drawing.Point(184, 42);
            this.lbl_Z2Servo_ActualPosition.Name = "lbl_Z2Servo_ActualPosition";
            this.lbl_Z2Servo_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_Z2Servo_ActualPosition.TabIndex = 53;
            this.lbl_Z2Servo_ActualPosition.Text = "0";
            this.lbl_Z2Servo_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label347
            // 
            this.label347.AutoSize = true;
            this.label347.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label347.Location = new System.Drawing.Point(291, 45);
            this.label347.Name = "label347";
            this.label347.Size = new System.Drawing.Size(37, 14);
            this.label347.TabIndex = 75;
            this.label347.Text = "(mm)";
            // 
            // label348
            // 
            this.label348.AutoSize = true;
            this.label348.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label348.Location = new System.Drawing.Point(28, 45);
            this.label348.Name = "label348";
            this.label348.Size = new System.Drawing.Size(139, 14);
            this.label348.TabIndex = 52;
            this.label348.Text = "Servo Actual Position";
            // 
            // groupBox78
            // 
            this.groupBox78.Controls.Add(this.button74);
            this.groupBox78.Controls.Add(this.button75);
            this.groupBox78.Controls.Add(this.textBox60);
            this.groupBox78.Controls.Add(this.textBox61);
            this.groupBox78.Controls.Add(this.textBox62);
            this.groupBox78.Controls.Add(this.label349);
            this.groupBox78.Controls.Add(this.label350);
            this.groupBox78.Controls.Add(this.textBox63);
            this.groupBox78.Controls.Add(this.label351);
            this.groupBox78.Controls.Add(this.textBox64);
            this.groupBox78.Controls.Add(this.label352);
            this.groupBox78.Controls.Add(this.label353);
            this.groupBox78.Controls.Add(this.label354);
            this.groupBox78.Controls.Add(this.label355);
            this.groupBox78.Controls.Add(this.label357);
            this.groupBox78.Controls.Add(this.label358);
            this.groupBox78.Controls.Add(this.label359);
            this.groupBox78.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox78.Location = new System.Drawing.Point(141, 326);
            this.groupBox78.Name = "groupBox78";
            this.groupBox78.Size = new System.Drawing.Size(781, 149);
            this.groupBox78.TabIndex = 73;
            this.groupBox78.TabStop = false;
            this.groupBox78.Text = "Point To Point Control";
            // 
            // button74
            // 
            this.button74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button74.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button74.ForeColor = System.Drawing.Color.White;
            this.button74.Location = new System.Drawing.Point(399, 103);
            this.button74.Name = "button74";
            this.button74.Size = new System.Drawing.Size(83, 38);
            this.button74.TabIndex = 71;
            this.button74.Text = "Stop";
            this.button74.UseVisualStyleBackColor = false;
            // 
            // button75
            // 
            this.button75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button75.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button75.ForeColor = System.Drawing.Color.White;
            this.button75.Location = new System.Drawing.Point(203, 103);
            this.button75.Name = "button75";
            this.button75.Size = new System.Drawing.Size(83, 38);
            this.button75.TabIndex = 70;
            this.button75.Text = "Move";
            this.button75.UseVisualStyleBackColor = false;
            // 
            // textBox60
            // 
            this.textBox60.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox60.Location = new System.Drawing.Point(603, 28);
            this.textBox60.Name = "textBox60";
            this.textBox60.Size = new System.Drawing.Size(67, 26);
            this.textBox60.TabIndex = 61;
            // 
            // textBox61
            // 
            this.textBox61.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox61.Location = new System.Drawing.Point(336, 65);
            this.textBox61.Name = "textBox61";
            this.textBox61.Size = new System.Drawing.Size(67, 26);
            this.textBox61.TabIndex = 61;
            // 
            // textBox62
            // 
            this.textBox62.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox62.Location = new System.Drawing.Point(336, 28);
            this.textBox62.Name = "textBox62";
            this.textBox62.Size = new System.Drawing.Size(67, 26);
            this.textBox62.TabIndex = 61;
            // 
            // label349
            // 
            this.label349.AutoSize = true;
            this.label349.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label349.Location = new System.Drawing.Point(21, 80);
            this.label349.Name = "label349";
            this.label349.Size = new System.Drawing.Size(84, 14);
            this.label349.TabIndex = 37;
            this.label349.Text = "End Position";
            // 
            // label350
            // 
            this.label350.AutoSize = true;
            this.label350.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label350.Location = new System.Drawing.Point(14, 40);
            this.label350.Name = "label350";
            this.label350.Size = new System.Drawing.Size(93, 14);
            this.label350.TabIndex = 37;
            this.label350.Text = "Start Position";
            // 
            // textBox63
            // 
            this.textBox63.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox63.Location = new System.Drawing.Point(105, 71);
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new System.Drawing.Size(67, 26);
            this.textBox63.TabIndex = 59;
            // 
            // label351
            // 
            this.label351.AutoSize = true;
            this.label351.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label351.Location = new System.Drawing.Point(539, 40);
            this.label351.Name = "label351";
            this.label351.Size = new System.Drawing.Size(62, 14);
            this.label351.TabIndex = 60;
            this.label351.Text = "Iteration";
            // 
            // textBox64
            // 
            this.textBox64.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox64.Location = new System.Drawing.Point(105, 32);
            this.textBox64.Name = "textBox64";
            this.textBox64.Size = new System.Drawing.Size(67, 26);
            this.textBox64.TabIndex = 59;
            // 
            // label352
            // 
            this.label352.AutoSize = true;
            this.label352.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label352.Location = new System.Drawing.Point(297, 76);
            this.label352.Name = "label352";
            this.label352.Size = new System.Drawing.Size(35, 14);
            this.label352.TabIndex = 60;
            this.label352.Text = "Wait";
            // 
            // label353
            // 
            this.label353.AutoSize = true;
            this.label353.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label353.Location = new System.Drawing.Point(179, 80);
            this.label353.Name = "label353";
            this.label353.Size = new System.Drawing.Size(37, 14);
            this.label353.TabIndex = 66;
            this.label353.Text = "(mm)";
            // 
            // label354
            // 
            this.label354.AutoSize = true;
            this.label354.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label354.Location = new System.Drawing.Point(676, 40);
            this.label354.Name = "label354";
            this.label354.Size = new System.Drawing.Size(39, 14);
            this.label354.TabIndex = 67;
            this.label354.Text = "count";
            // 
            // label355
            // 
            this.label355.AutoSize = true;
            this.label355.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label355.Location = new System.Drawing.Point(287, 40);
            this.label355.Name = "label355";
            this.label355.Size = new System.Drawing.Size(45, 14);
            this.label355.TabIndex = 60;
            this.label355.Text = "Speed";
            // 
            // label357
            // 
            this.label357.AutoSize = true;
            this.label357.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label357.Location = new System.Drawing.Point(410, 76);
            this.label357.Name = "label357";
            this.label357.Size = new System.Drawing.Size(25, 14);
            this.label357.TabIndex = 67;
            this.label357.Text = "sec";
            // 
            // label358
            // 
            this.label358.AutoSize = true;
            this.label358.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label358.Location = new System.Drawing.Point(179, 40);
            this.label358.Name = "label358";
            this.label358.Size = new System.Drawing.Size(37, 14);
            this.label358.TabIndex = 66;
            this.label358.Text = "(mm)";
            // 
            // label359
            // 
            this.label359.AutoSize = true;
            this.label359.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label359.Location = new System.Drawing.Point(410, 40);
            this.label359.Name = "label359";
            this.label359.Size = new System.Drawing.Size(47, 14);
            this.label359.TabIndex = 67;
            this.label359.Text = "(mm/s)";
            // 
            // groupBox83
            // 
            this.groupBox83.BackColor = System.Drawing.Color.White;
            this.groupBox83.Controls.Add(this.comboBox6);
            this.groupBox83.Controls.Add(this.label360);
            this.groupBox83.Controls.Add(this.textBox65);
            this.groupBox83.Controls.Add(this.label361);
            this.groupBox83.Controls.Add(this.label364);
            this.groupBox83.Controls.Add(this.button76);
            this.groupBox83.Controls.Add(this.button77);
            this.groupBox83.Controls.Add(this.label365);
            this.groupBox83.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox83.Location = new System.Drawing.Point(815, 153);
            this.groupBox83.Name = "groupBox83";
            this.groupBox83.Size = new System.Drawing.Size(249, 165);
            this.groupBox83.TabIndex = 72;
            this.groupBox83.TabStop = false;
            this.groupBox83.Text = "Jog Control";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox6.Location = new System.Drawing.Point(105, 64);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(67, 26);
            this.comboBox6.TabIndex = 78;
            this.comboBox6.Visible = false;
            // 
            // label360
            // 
            this.label360.AutoSize = true;
            this.label360.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label360.Location = new System.Drawing.Point(176, 41);
            this.label360.Name = "label360";
            this.label360.Size = new System.Drawing.Size(37, 14);
            this.label360.TabIndex = 77;
            this.label360.Text = "(mm)";
            this.label360.Visible = false;
            // 
            // textBox65
            // 
            this.textBox65.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox65.Location = new System.Drawing.Point(105, 32);
            this.textBox65.Name = "textBox65";
            this.textBox65.Size = new System.Drawing.Size(67, 26);
            this.textBox65.TabIndex = 76;
            this.textBox65.Visible = false;
            // 
            // label361
            // 
            this.label361.AutoSize = true;
            this.label361.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label361.Location = new System.Drawing.Point(20, 40);
            this.label361.Name = "label361";
            this.label361.Size = new System.Drawing.Size(83, 14);
            this.label361.TabIndex = 75;
            this.label361.Text = "Jog Position";
            this.label361.Visible = false;
            // 
            // label364
            // 
            this.label364.AutoSize = true;
            this.label364.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label364.Location = new System.Drawing.Point(172, 71);
            this.label364.Name = "label364";
            this.label364.Size = new System.Drawing.Size(47, 14);
            this.label364.TabIndex = 73;
            this.label364.Text = "(mm/s)";
            this.label364.Visible = false;
            // 
            // button76
            // 
            this.button76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button76.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button76.ForeColor = System.Drawing.Color.White;
            this.button76.Location = new System.Drawing.Point(123, 107);
            this.button76.Name = "button76";
            this.button76.Size = new System.Drawing.Size(83, 38);
            this.button76.TabIndex = 74;
            this.button76.Text = "Jog -";
            this.button76.UseVisualStyleBackColor = false;
            // 
            // button77
            // 
            this.button77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button77.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button77.ForeColor = System.Drawing.Color.White;
            this.button77.Location = new System.Drawing.Point(24, 107);
            this.button77.Name = "button77";
            this.button77.Size = new System.Drawing.Size(83, 38);
            this.button77.TabIndex = 73;
            this.button77.Text = "Jog +";
            this.button77.UseVisualStyleBackColor = false;
            // 
            // label365
            // 
            this.label365.AutoSize = true;
            this.label365.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label365.Location = new System.Drawing.Point(20, 72);
            this.label365.Name = "label365";
            this.label365.Size = new System.Drawing.Size(81, 14);
            this.label365.TabIndex = 37;
            this.label365.Text = "Jog Velocity";
            this.label365.Visible = false;
            // 
            // groupBox86
            // 
            this.groupBox86.BackColor = System.Drawing.Color.White;
            this.groupBox86.Controls.Add(this.btn_Z2stop_home);
            this.groupBox86.Controls.Add(this.label366);
            this.groupBox86.Controls.Add(this.btnScrewHome_Z2);
            this.groupBox86.Controls.Add(this.textBox66);
            this.groupBox86.Controls.Add(this.label367);
            this.groupBox86.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox86.Location = new System.Drawing.Point(531, 153);
            this.groupBox86.Name = "groupBox86";
            this.groupBox86.Size = new System.Drawing.Size(249, 165);
            this.groupBox86.TabIndex = 71;
            this.groupBox86.TabStop = false;
            this.groupBox86.Text = "Homing Control";
            // 
            // btn_Z2stop_home
            // 
            this.btn_Z2stop_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_Z2stop_home.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Z2stop_home.ForeColor = System.Drawing.Color.White;
            this.btn_Z2stop_home.Location = new System.Drawing.Point(132, 105);
            this.btn_Z2stop_home.Name = "btn_Z2stop_home";
            this.btn_Z2stop_home.Size = new System.Drawing.Size(83, 38);
            this.btn_Z2stop_home.TabIndex = 72;
            this.btn_Z2stop_home.Text = "Stop";
            this.btn_Z2stop_home.UseVisualStyleBackColor = false;
            // 
            // label366
            // 
            this.label366.AutoSize = true;
            this.label366.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label366.Location = new System.Drawing.Point(179, 55);
            this.label366.Name = "label366";
            this.label366.Size = new System.Drawing.Size(47, 14);
            this.label366.TabIndex = 72;
            this.label366.Text = "(mm/s)";
            // 
            // btnScrewHome_Z2
            // 
            this.btnScrewHome_Z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewHome_Z2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewHome_Z2.ForeColor = System.Drawing.Color.White;
            this.btnScrewHome_Z2.Location = new System.Drawing.Point(19, 105);
            this.btnScrewHome_Z2.Name = "btnScrewHome_Z2";
            this.btnScrewHome_Z2.Size = new System.Drawing.Size(83, 38);
            this.btnScrewHome_Z2.TabIndex = 72;
            this.btnScrewHome_Z2.Text = "Home";
            this.btnScrewHome_Z2.UseVisualStyleBackColor = false;
            // 
            // textBox66
            // 
            this.textBox66.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox66.Location = new System.Drawing.Point(108, 47);
            this.textBox66.Name = "textBox66";
            this.textBox66.Size = new System.Drawing.Size(67, 26);
            this.textBox66.TabIndex = 59;
            // 
            // label367
            // 
            this.label367.AutoSize = true;
            this.label367.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label367.Location = new System.Drawing.Point(9, 55);
            this.label367.Name = "label367";
            this.label367.Size = new System.Drawing.Size(94, 14);
            this.label367.TabIndex = 37;
            this.label367.Text = "Home Velocity";
            // 
            // groupBox88
            // 
            this.groupBox88.BackColor = System.Drawing.Color.White;
            this.groupBox88.Controls.Add(this.btn_Z2ScrewMove_stop);
            this.groupBox88.Controls.Add(this.btnScrewSVMove_Z2);
            this.groupBox88.Controls.Add(this.label368);
            this.groupBox88.Controls.Add(this.label369);
            this.groupBox88.Controls.Add(this.lbl_Z2ScrewSV_TargetSpeed);
            this.groupBox88.Controls.Add(this.label370);
            this.groupBox88.Controls.Add(this.lbl_Z2ScrewSV_TargetPosition);
            this.groupBox88.Controls.Add(this.label371);
            this.groupBox88.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox88.Location = new System.Drawing.Point(271, 149);
            this.groupBox88.Name = "groupBox88";
            this.groupBox88.Size = new System.Drawing.Size(219, 168);
            this.groupBox88.TabIndex = 56;
            this.groupBox88.TabStop = false;
            this.groupBox88.Text = "Motion Control";
            // 
            // btn_Z2ScrewMove_stop
            // 
            this.btn_Z2ScrewMove_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_Z2ScrewMove_stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Z2ScrewMove_stop.ForeColor = System.Drawing.Color.White;
            this.btn_Z2ScrewMove_stop.Location = new System.Drawing.Point(119, 107);
            this.btn_Z2ScrewMove_stop.Name = "btn_Z2ScrewMove_stop";
            this.btn_Z2ScrewMove_stop.Size = new System.Drawing.Size(83, 38);
            this.btn_Z2ScrewMove_stop.TabIndex = 73;
            this.btn_Z2ScrewMove_stop.Text = "Stop";
            this.btn_Z2ScrewMove_stop.UseVisualStyleBackColor = false;
            // 
            // btnScrewSVMove_Z2
            // 
            this.btnScrewSVMove_Z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScrewSVMove_Z2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrewSVMove_Z2.ForeColor = System.Drawing.Color.White;
            this.btnScrewSVMove_Z2.Location = new System.Drawing.Point(18, 107);
            this.btnScrewSVMove_Z2.Name = "btnScrewSVMove_Z2";
            this.btnScrewSVMove_Z2.Size = new System.Drawing.Size(83, 38);
            this.btnScrewSVMove_Z2.TabIndex = 70;
            this.btnScrewSVMove_Z2.Text = "Move";
            this.btnScrewSVMove_Z2.UseVisualStyleBackColor = false;
            // 
            // label368
            // 
            this.label368.AutoSize = true;
            this.label368.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label368.Location = new System.Drawing.Point(159, 79);
            this.label368.Name = "label368";
            this.label368.Size = new System.Drawing.Size(47, 14);
            this.label368.TabIndex = 67;
            this.label368.Text = "(mm/s)";
            // 
            // label369
            // 
            this.label369.AutoSize = true;
            this.label369.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label369.Location = new System.Drawing.Point(159, 37);
            this.label369.Name = "label369";
            this.label369.Size = new System.Drawing.Size(37, 14);
            this.label369.TabIndex = 66;
            this.label369.Text = "(mm)";
            // 
            // lbl_Z2ScrewSV_TargetSpeed
            // 
            this.lbl_Z2ScrewSV_TargetSpeed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Z2ScrewSV_TargetSpeed.Location = new System.Drawing.Point(85, 66);
            this.lbl_Z2ScrewSV_TargetSpeed.Name = "lbl_Z2ScrewSV_TargetSpeed";
            this.lbl_Z2ScrewSV_TargetSpeed.Size = new System.Drawing.Size(67, 26);
            this.lbl_Z2ScrewSV_TargetSpeed.TabIndex = 61;
            // 
            // label370
            // 
            this.label370.AutoSize = true;
            this.label370.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label370.Location = new System.Drawing.Point(23, 73);
            this.label370.Name = "label370";
            this.label370.Size = new System.Drawing.Size(45, 14);
            this.label370.TabIndex = 60;
            this.label370.Text = "Speed";
            // 
            // lbl_Z2ScrewSV_TargetPosition
            // 
            this.lbl_Z2ScrewSV_TargetPosition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Z2ScrewSV_TargetPosition.Location = new System.Drawing.Point(85, 29);
            this.lbl_Z2ScrewSV_TargetPosition.Name = "lbl_Z2ScrewSV_TargetPosition";
            this.lbl_Z2ScrewSV_TargetPosition.Size = new System.Drawing.Size(67, 26);
            this.lbl_Z2ScrewSV_TargetPosition.TabIndex = 59;
            // 
            // label371
            // 
            this.label371.AutoSize = true;
            this.label371.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label371.Location = new System.Drawing.Point(23, 36);
            this.label371.Name = "label371";
            this.label371.Size = new System.Drawing.Size(57, 14);
            this.label371.TabIndex = 37;
            this.label371.Text = "Position";
            // 
            // groupBox93
            // 
            this.groupBox93.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox93.Controls.Add(this.lblScrewServoZ2disable);
            this.groupBox93.Controls.Add(this.label373);
            this.groupBox93.Controls.Add(this.lblScrewServoZ2Error);
            this.groupBox93.Controls.Add(this.label375);
            this.groupBox93.Controls.Add(this.lblScrewServoZ2Positive_limit);
            this.groupBox93.Controls.Add(this.label377);
            this.groupBox93.Controls.Add(this.lblScrewServoZ2Home);
            this.groupBox93.Controls.Add(this.lblScrewServoZ2Running);
            this.groupBox93.Controls.Add(this.lblScrewServoZ2Ready);
            this.groupBox93.Controls.Add(this.lblScrewServoZ2Negative_limit);
            this.groupBox93.Controls.Add(this.lblScrewServoZ2Enable);
            this.groupBox93.Controls.Add(this.label383);
            this.groupBox93.Controls.Add(this.label384);
            this.groupBox93.Controls.Add(this.label385);
            this.groupBox93.Controls.Add(this.label390);
            this.groupBox93.Controls.Add(this.label391);
            this.groupBox93.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox93.Location = new System.Drawing.Point(17, 14);
            this.groupBox93.Name = "groupBox93";
            this.groupBox93.Size = new System.Drawing.Size(715, 128);
            this.groupBox93.TabIndex = 37;
            this.groupBox93.TabStop = false;
            this.groupBox93.Text = "Device Status";
            // 
            // lblScrewServoZ2disable
            // 
            this.lblScrewServoZ2disable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ2disable.Location = new System.Drawing.Point(111, 87);
            this.lblScrewServoZ2disable.Name = "lblScrewServoZ2disable";
            this.lblScrewServoZ2disable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ2disable.TabIndex = 67;
            // 
            // label373
            // 
            this.label373.AutoSize = true;
            this.label373.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label373.Location = new System.Drawing.Point(20, 94);
            this.label373.Name = "label373";
            this.label373.Size = new System.Drawing.Size(89, 14);
            this.label373.TabIndex = 66;
            this.label373.Text = "Servo Disable";
            // 
            // lblScrewServoZ2Error
            // 
            this.lblScrewServoZ2Error.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ2Error.Location = new System.Drawing.Point(467, 87);
            this.lblScrewServoZ2Error.Name = "lblScrewServoZ2Error";
            this.lblScrewServoZ2Error.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ2Error.TabIndex = 61;
            // 
            // label375
            // 
            this.label375.AutoSize = true;
            this.label375.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label375.Location = new System.Drawing.Point(373, 94);
            this.label375.Name = "label375";
            this.label375.Size = new System.Drawing.Size(93, 14);
            this.label375.TabIndex = 60;
            this.label375.Text = "Servo In Error";
            // 
            // lblScrewServoZ2Positive_limit
            // 
            this.lblScrewServoZ2Positive_limit.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ2Positive_limit.Location = new System.Drawing.Point(661, 87);
            this.lblScrewServoZ2Positive_limit.Name = "lblScrewServoZ2Positive_limit";
            this.lblScrewServoZ2Positive_limit.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ2Positive_limit.TabIndex = 59;
            // 
            // label377
            // 
            this.label377.AutoSize = true;
            this.label377.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label377.Location = new System.Drawing.Point(568, 94);
            this.label377.Name = "label377";
            this.label377.Size = new System.Drawing.Size(89, 14);
            this.label377.TabIndex = 56;
            this.label377.Text = "Positive Limit";
            // 
            // lblScrewServoZ2Home
            // 
            this.lblScrewServoZ2Home.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ2Home.Location = new System.Drawing.Point(467, 36);
            this.lblScrewServoZ2Home.Name = "lblScrewServoZ2Home";
            this.lblScrewServoZ2Home.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ2Home.TabIndex = 48;
            // 
            // lblScrewServoZ2Running
            // 
            this.lblScrewServoZ2Running.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ2Running.Location = new System.Drawing.Point(291, 87);
            this.lblScrewServoZ2Running.Name = "lblScrewServoZ2Running";
            this.lblScrewServoZ2Running.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ2Running.TabIndex = 47;
            // 
            // lblScrewServoZ2Ready
            // 
            this.lblScrewServoZ2Ready.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ2Ready.Location = new System.Drawing.Point(291, 33);
            this.lblScrewServoZ2Ready.Name = "lblScrewServoZ2Ready";
            this.lblScrewServoZ2Ready.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ2Ready.TabIndex = 46;
            // 
            // lblScrewServoZ2Negative_limit
            // 
            this.lblScrewServoZ2Negative_limit.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ2Negative_limit.Location = new System.Drawing.Point(661, 33);
            this.lblScrewServoZ2Negative_limit.Name = "lblScrewServoZ2Negative_limit";
            this.lblScrewServoZ2Negative_limit.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ2Negative_limit.TabIndex = 45;
            // 
            // lblScrewServoZ2Enable
            // 
            this.lblScrewServoZ2Enable.BackColor = System.Drawing.Color.Maroon;
            this.lblScrewServoZ2Enable.Location = new System.Drawing.Point(111, 33);
            this.lblScrewServoZ2Enable.Name = "lblScrewServoZ2Enable";
            this.lblScrewServoZ2Enable.Size = new System.Drawing.Size(27, 26);
            this.lblScrewServoZ2Enable.TabIndex = 45;
            // 
            // label383
            // 
            this.label383.AutoSize = true;
            this.label383.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label383.Location = new System.Drawing.Point(193, 94);
            this.label383.Name = "label383";
            this.label383.Size = new System.Drawing.Size(98, 14);
            this.label383.TabIndex = 43;
            this.label383.Text = "Servo Running";
            // 
            // label384
            // 
            this.label384.AutoSize = true;
            this.label384.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label384.Location = new System.Drawing.Point(385, 44);
            this.label384.Name = "label384";
            this.label384.Size = new System.Drawing.Size(81, 14);
            this.label384.TabIndex = 41;
            this.label384.Text = "Servo Home";
            // 
            // label385
            // 
            this.label385.AutoSize = true;
            this.label385.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label385.Location = new System.Drawing.Point(562, 41);
            this.label385.Name = "label385";
            this.label385.Size = new System.Drawing.Size(94, 14);
            this.label385.TabIndex = 37;
            this.label385.Text = "Negative Limit";
            // 
            // label390
            // 
            this.label390.AutoSize = true;
            this.label390.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label390.Location = new System.Drawing.Point(207, 41);
            this.label390.Name = "label390";
            this.label390.Size = new System.Drawing.Size(84, 14);
            this.label390.TabIndex = 39;
            this.label390.Text = "Servo Ready";
            // 
            // label391
            // 
            this.label391.AutoSize = true;
            this.label391.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label391.Location = new System.Drawing.Point(20, 41);
            this.label391.Name = "label391";
            this.label391.Size = new System.Drawing.Size(86, 14);
            this.label391.TabIndex = 37;
            this.label391.Text = "Servo Enable";
            // 
            // Feeder
            // 
            this.Feeder.BackColor = System.Drawing.Color.LightGray;
            this.Feeder.Controls.Add(this.button18);
            this.Feeder.Controls.Add(this.button16);
            this.Feeder.Controls.Add(this.button15);
            this.Feeder.Controls.Add(this.label35);
            this.Feeder.Controls.Add(this.tabFeeder);
            this.Feeder.Location = new System.Drawing.Point(4, 27);
            this.Feeder.Name = "Feeder";
            this.Feeder.Padding = new System.Windows.Forms.Padding(3);
            this.Feeder.Size = new System.Drawing.Size(1420, 671);
            this.Feeder.TabIndex = 1;
            this.Feeder.Text = "FEEDER";
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(939, 40);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(84, 33);
            this.button18.TabIndex = 81;
            this.button18.Text = "Flipper";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(1205, 40);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(111, 33);
            this.button16.TabIndex = 80;
            this.button16.Text = "Stop";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(1059, 40);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(141, 33);
            this.button15.TabIndex = 79;
            this.button15.Text = "StartDryCycle";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(703, 20);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(101, 25);
            this.label35.TabIndex = 78;
            this.label35.Text = "FEEDER";
            // 
            // tabFeeder
            // 
            this.tabFeeder.Controls.Add(this.Loader);
            this.tabFeeder.Controls.Add(this.Unloader);
            this.tabFeeder.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFeeder.Location = new System.Drawing.Point(9, 69);
            this.tabFeeder.Name = "tabFeeder";
            this.tabFeeder.SelectedIndex = 0;
            this.tabFeeder.Size = new System.Drawing.Size(1569, 632);
            this.tabFeeder.TabIndex = 76;
            // 
            // Loader
            // 
            this.Loader.BackColor = System.Drawing.Color.LightGray;
            this.Loader.Controls.Add(this.groupBox1);
            this.Loader.Location = new System.Drawing.Point(4, 27);
            this.Loader.Name = "Loader";
            this.Loader.Padding = new System.Windows.Forms.Padding(3);
            this.Loader.Size = new System.Drawing.Size(1561, 601);
            this.Loader.TabIndex = 0;
            this.Loader.Text = "Loader";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox23);
            this.groupBox1.Controls.Add(this.groupBox24);
            this.groupBox1.Controls.Add(this.groupBox25);
            this.groupBox1.Controls.Add(this.groupBox26);
            this.groupBox1.Controls.Add(this.groupBox27);
            this.groupBox1.Controls.Add(this.groupBox28);
            this.groupBox1.Controls.Add(this.groupBox29);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(239, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1053, 485);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBreakEnable_Loader);
            this.groupBox2.Controls.Add(this.btnBreakDisable_Loader);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 144);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Break Control";
            // 
            // btnBreakEnable_Loader
            // 
            this.btnBreakEnable_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnBreakEnable_Loader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBreakEnable_Loader.ForeColor = System.Drawing.Color.White;
            this.btnBreakEnable_Loader.Location = new System.Drawing.Point(9, 34);
            this.btnBreakEnable_Loader.Name = "btnBreakEnable_Loader";
            this.btnBreakEnable_Loader.Size = new System.Drawing.Size(147, 38);
            this.btnBreakEnable_Loader.TabIndex = 71;
            this.btnBreakEnable_Loader.Text = "Break Enable";
            this.btnBreakEnable_Loader.UseVisualStyleBackColor = false;
            // 
            // btnBreakDisable_Loader
            // 
            this.btnBreakDisable_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnBreakDisable_Loader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBreakDisable_Loader.ForeColor = System.Drawing.Color.White;
            this.btnBreakDisable_Loader.Location = new System.Drawing.Point(9, 85);
            this.btnBreakDisable_Loader.Name = "btnBreakDisable_Loader";
            this.btnBreakDisable_Loader.Size = new System.Drawing.Size(147, 38);
            this.btnBreakDisable_Loader.TabIndex = 71;
            this.btnBreakDisable_Loader.Text = "Break Disable";
            this.btnBreakDisable_Loader.UseVisualStyleBackColor = false;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.btnServoLoaderEnable);
            this.groupBox23.Controls.Add(this.btnServoLoaderClearErr);
            this.groupBox23.Controls.Add(this.btnServoLoaderDisable);
            this.groupBox23.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox23.Location = new System.Drawing.Point(15, 149);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(177, 168);
            this.groupBox23.TabIndex = 75;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Device Control";
            // 
            // btnServoLoaderEnable
            // 
            this.btnServoLoaderEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnServoLoaderEnable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServoLoaderEnable.ForeColor = System.Drawing.Color.White;
            this.btnServoLoaderEnable.Location = new System.Drawing.Point(11, 26);
            this.btnServoLoaderEnable.Name = "btnServoLoaderEnable";
            this.btnServoLoaderEnable.Size = new System.Drawing.Size(147, 38);
            this.btnServoLoaderEnable.TabIndex = 71;
            this.btnServoLoaderEnable.Text = "Servo Enable";
            this.btnServoLoaderEnable.UseVisualStyleBackColor = false;
            // 
            // btnServoLoaderClearErr
            // 
            this.btnServoLoaderClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnServoLoaderClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServoLoaderClearErr.ForeColor = System.Drawing.Color.White;
            this.btnServoLoaderClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnServoLoaderClearErr.Name = "btnServoLoaderClearErr";
            this.btnServoLoaderClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnServoLoaderClearErr.TabIndex = 71;
            this.btnServoLoaderClearErr.Text = "Servo Clear Error";
            this.btnServoLoaderClearErr.UseVisualStyleBackColor = false;
            // 
            // btnServoLoaderDisable
            // 
            this.btnServoLoaderDisable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnServoLoaderDisable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServoLoaderDisable.ForeColor = System.Drawing.Color.White;
            this.btnServoLoaderDisable.Location = new System.Drawing.Point(11, 70);
            this.btnServoLoaderDisable.Name = "btnServoLoaderDisable";
            this.btnServoLoaderDisable.Size = new System.Drawing.Size(147, 38);
            this.btnServoLoaderDisable.TabIndex = 71;
            this.btnServoLoaderDisable.Text = "Servo Disable";
            this.btnServoLoaderDisable.UseVisualStyleBackColor = false;
            // 
            // groupBox24
            // 
            this.groupBox24.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox24.Controls.Add(this.label107);
            this.groupBox24.Controls.Add(this.lbl_loader_ActualPosition);
            this.groupBox24.Controls.Add(this.label109);
            this.groupBox24.Controls.Add(this.label112);
            this.groupBox24.Controls.Add(this.label113);
            this.groupBox24.Controls.Add(this.lbl_loader_ActualVelocity);
            this.groupBox24.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox24.Location = new System.Drawing.Point(732, 14);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(297, 128);
            this.groupBox24.TabIndex = 74;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Live Values";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label107.Location = new System.Drawing.Point(247, 77);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(47, 14);
            this.label107.TabIndex = 73;
            this.label107.Text = "(mm/s)";
            // 
            // lbl_loader_ActualPosition
            // 
            this.lbl_loader_ActualPosition.AutoSize = true;
            this.lbl_loader_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_loader_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_loader_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loader_ActualPosition.Location = new System.Drawing.Point(172, 50);
            this.lbl_loader_ActualPosition.Name = "lbl_loader_ActualPosition";
            this.lbl_loader_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_loader_ActualPosition.TabIndex = 53;
            this.lbl_loader_ActualPosition.Text = "0";
            this.lbl_loader_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label109.Location = new System.Drawing.Point(247, 50);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(37, 14);
            this.label109.TabIndex = 75;
            this.label109.Text = "(mm)";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label112.Location = new System.Drawing.Point(16, 50);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(139, 14);
            this.label112.TabIndex = 52;
            this.label112.Text = "Servo Actual Position";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label113.Location = new System.Drawing.Point(16, 77);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(137, 14);
            this.label113.TabIndex = 54;
            this.label113.Text = "Servo Actual Velocity";
            // 
            // lbl_loader_ActualVelocity
            // 
            this.lbl_loader_ActualVelocity.AutoSize = true;
            this.lbl_loader_ActualVelocity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_loader_ActualVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_loader_ActualVelocity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loader_ActualVelocity.Location = new System.Drawing.Point(172, 77);
            this.lbl_loader_ActualVelocity.Name = "lbl_loader_ActualVelocity";
            this.lbl_loader_ActualVelocity.Size = new System.Drawing.Size(18, 16);
            this.lbl_loader_ActualVelocity.TabIndex = 55;
            this.lbl_loader_ActualVelocity.Text = "0";
            this.lbl_loader_ActualVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.btnLoader_Stop);
            this.groupBox25.Controls.Add(this.btnLoader_Move_point);
            this.groupBox25.Controls.Add(this.textBox25);
            this.groupBox25.Controls.Add(this.textBox26);
            this.groupBox25.Controls.Add(this.textBox27);
            this.groupBox25.Controls.Add(this.label115);
            this.groupBox25.Controls.Add(this.label116);
            this.groupBox25.Controls.Add(this.textBox28);
            this.groupBox25.Controls.Add(this.label117);
            this.groupBox25.Controls.Add(this.textBox29);
            this.groupBox25.Controls.Add(this.label118);
            this.groupBox25.Controls.Add(this.label119);
            this.groupBox25.Controls.Add(this.label120);
            this.groupBox25.Controls.Add(this.label121);
            this.groupBox25.Controls.Add(this.label122);
            this.groupBox25.Controls.Add(this.label123);
            this.groupBox25.Controls.Add(this.label124);
            this.groupBox25.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox25.Location = new System.Drawing.Point(247, 326);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(781, 149);
            this.groupBox25.TabIndex = 73;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Point To Point Control";
            // 
            // btnLoader_Stop
            // 
            this.btnLoader_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnLoader_Stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoader_Stop.ForeColor = System.Drawing.Color.White;
            this.btnLoader_Stop.Location = new System.Drawing.Point(399, 103);
            this.btnLoader_Stop.Name = "btnLoader_Stop";
            this.btnLoader_Stop.Size = new System.Drawing.Size(83, 38);
            this.btnLoader_Stop.TabIndex = 71;
            this.btnLoader_Stop.Text = "Stop";
            this.btnLoader_Stop.UseVisualStyleBackColor = false;
            // 
            // btnLoader_Move_point
            // 
            this.btnLoader_Move_point.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnLoader_Move_point.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoader_Move_point.ForeColor = System.Drawing.Color.White;
            this.btnLoader_Move_point.Location = new System.Drawing.Point(203, 103);
            this.btnLoader_Move_point.Name = "btnLoader_Move_point";
            this.btnLoader_Move_point.Size = new System.Drawing.Size(83, 38);
            this.btnLoader_Move_point.TabIndex = 70;
            this.btnLoader_Move_point.Text = "Move";
            this.btnLoader_Move_point.UseVisualStyleBackColor = false;
            // 
            // textBox25
            // 
            this.textBox25.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox25.Location = new System.Drawing.Point(603, 28);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(67, 26);
            this.textBox25.TabIndex = 61;
            // 
            // textBox26
            // 
            this.textBox26.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox26.Location = new System.Drawing.Point(336, 65);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(67, 26);
            this.textBox26.TabIndex = 61;
            // 
            // textBox27
            // 
            this.textBox27.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox27.Location = new System.Drawing.Point(336, 28);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(67, 26);
            this.textBox27.TabIndex = 61;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.Location = new System.Drawing.Point(21, 80);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(84, 14);
            this.label115.TabIndex = 37;
            this.label115.Text = "End Position";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(14, 40);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(93, 14);
            this.label116.TabIndex = 37;
            this.label116.Text = "Start Position";
            // 
            // textBox28
            // 
            this.textBox28.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox28.Location = new System.Drawing.Point(105, 71);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(67, 26);
            this.textBox28.TabIndex = 59;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(539, 40);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(62, 14);
            this.label117.TabIndex = 60;
            this.label117.Text = "Iteration";
            // 
            // textBox29
            // 
            this.textBox29.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox29.Location = new System.Drawing.Point(105, 32);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(67, 26);
            this.textBox29.TabIndex = 59;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.Location = new System.Drawing.Point(297, 76);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(35, 14);
            this.label118.TabIndex = 60;
            this.label118.Text = "Wait";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.Location = new System.Drawing.Point(179, 80);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(37, 14);
            this.label119.TabIndex = 66;
            this.label119.Text = "(mm)";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label120.Location = new System.Drawing.Point(676, 40);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(39, 14);
            this.label120.TabIndex = 67;
            this.label120.Text = "count";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label121.Location = new System.Drawing.Point(287, 40);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(45, 14);
            this.label121.TabIndex = 60;
            this.label121.Text = "Speed";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label122.Location = new System.Drawing.Point(410, 76);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(25, 14);
            this.label122.TabIndex = 67;
            this.label122.Text = "sec";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label123.Location = new System.Drawing.Point(179, 40);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(37, 14);
            this.label123.TabIndex = 66;
            this.label123.Text = "(mm)";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label124.Location = new System.Drawing.Point(410, 40);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(47, 14);
            this.label124.TabIndex = 67;
            this.label124.Text = "(mm/s)";
            // 
            // groupBox26
            // 
            this.groupBox26.BackColor = System.Drawing.Color.White;
            this.groupBox26.Controls.Add(this.txtJogVelocity_LHloader);
            this.groupBox26.Controls.Add(this.label125);
            this.groupBox26.Controls.Add(this.txtJogDist_LHloader);
            this.groupBox26.Controls.Add(this.label126);
            this.groupBox26.Controls.Add(this.label127);
            this.groupBox26.Controls.Add(this.btnJogDec_Loader);
            this.groupBox26.Controls.Add(this.btnJogAdd_Loader);
            this.groupBox26.Controls.Add(this.label128);
            this.groupBox26.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox26.Location = new System.Drawing.Point(795, 149);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(234, 168);
            this.groupBox26.TabIndex = 72;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Jog Control";
            // 
            // txtJogVelocity_LHloader
            // 
            this.txtJogVelocity_LHloader.FormattingEnabled = true;
            this.txtJogVelocity_LHloader.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.txtJogVelocity_LHloader.Location = new System.Drawing.Point(105, 64);
            this.txtJogVelocity_LHloader.Name = "txtJogVelocity_LHloader";
            this.txtJogVelocity_LHloader.Size = new System.Drawing.Size(67, 26);
            this.txtJogVelocity_LHloader.TabIndex = 78;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label125.Location = new System.Drawing.Point(176, 41);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(37, 14);
            this.label125.TabIndex = 77;
            this.label125.Text = "(mm)";
            // 
            // txtJogDist_LHloader
            // 
            this.txtJogDist_LHloader.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJogDist_LHloader.Location = new System.Drawing.Point(105, 32);
            this.txtJogDist_LHloader.Name = "txtJogDist_LHloader";
            this.txtJogDist_LHloader.Size = new System.Drawing.Size(67, 26);
            this.txtJogDist_LHloader.TabIndex = 76;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.Location = new System.Drawing.Point(20, 40);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(83, 14);
            this.label126.TabIndex = 75;
            this.label126.Text = "Jog Position";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.Location = new System.Drawing.Point(172, 71);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(47, 14);
            this.label127.TabIndex = 73;
            this.label127.Text = "(mm/s)";
            // 
            // btnJogDec_Loader
            // 
            this.btnJogDec_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogDec_Loader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogDec_Loader.ForeColor = System.Drawing.Color.White;
            this.btnJogDec_Loader.Location = new System.Drawing.Point(123, 107);
            this.btnJogDec_Loader.Name = "btnJogDec_Loader";
            this.btnJogDec_Loader.Size = new System.Drawing.Size(83, 38);
            this.btnJogDec_Loader.TabIndex = 74;
            this.btnJogDec_Loader.Text = "Jog -";
            this.btnJogDec_Loader.UseVisualStyleBackColor = false;
            // 
            // btnJogAdd_Loader
            // 
            this.btnJogAdd_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogAdd_Loader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogAdd_Loader.ForeColor = System.Drawing.Color.White;
            this.btnJogAdd_Loader.Location = new System.Drawing.Point(24, 107);
            this.btnJogAdd_Loader.Name = "btnJogAdd_Loader";
            this.btnJogAdd_Loader.Size = new System.Drawing.Size(83, 38);
            this.btnJogAdd_Loader.TabIndex = 73;
            this.btnJogAdd_Loader.Text = "Jog +";
            this.btnJogAdd_Loader.UseVisualStyleBackColor = false;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.Location = new System.Drawing.Point(20, 72);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(81, 14);
            this.label128.TabIndex = 37;
            this.label128.Text = "Jog Velocity";
            // 
            // groupBox27
            // 
            this.groupBox27.BackColor = System.Drawing.Color.White;
            this.groupBox27.Controls.Add(this.btnHome_Stop_Loader);
            this.groupBox27.Controls.Add(this.label129);
            this.groupBox27.Controls.Add(this.btnHome_Loader);
            this.groupBox27.Controls.Add(this.textBox31);
            this.groupBox27.Controls.Add(this.label130);
            this.groupBox27.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox27.Location = new System.Drawing.Point(507, 153);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(234, 168);
            this.groupBox27.TabIndex = 71;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Homing Control";
            // 
            // btnHome_Stop_Loader
            // 
            this.btnHome_Stop_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHome_Stop_Loader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome_Stop_Loader.ForeColor = System.Drawing.Color.White;
            this.btnHome_Stop_Loader.Location = new System.Drawing.Point(105, 107);
            this.btnHome_Stop_Loader.Name = "btnHome_Stop_Loader";
            this.btnHome_Stop_Loader.Size = new System.Drawing.Size(83, 38);
            this.btnHome_Stop_Loader.TabIndex = 73;
            this.btnHome_Stop_Loader.Text = "Stop";
            this.btnHome_Stop_Loader.UseVisualStyleBackColor = false;
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.Location = new System.Drawing.Point(179, 55);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(47, 14);
            this.label129.TabIndex = 72;
            this.label129.Text = "(mm/s)";
            // 
            // btnHome_Loader
            // 
            this.btnHome_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHome_Loader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome_Loader.ForeColor = System.Drawing.Color.White;
            this.btnHome_Loader.Location = new System.Drawing.Point(11, 111);
            this.btnHome_Loader.Name = "btnHome_Loader";
            this.btnHome_Loader.Size = new System.Drawing.Size(83, 38);
            this.btnHome_Loader.TabIndex = 72;
            this.btnHome_Loader.Text = "Home";
            this.btnHome_Loader.UseVisualStyleBackColor = false;
            // 
            // textBox31
            // 
            this.textBox31.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox31.Location = new System.Drawing.Point(108, 47);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(67, 26);
            this.textBox31.TabIndex = 59;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.Location = new System.Drawing.Point(9, 55);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(94, 14);
            this.label130.TabIndex = 37;
            this.label130.Text = "Home Velocity";
            // 
            // groupBox28
            // 
            this.groupBox28.BackColor = System.Drawing.Color.White;
            this.groupBox28.Controls.Add(this.btnMove_Stop_Loader);
            this.groupBox28.Controls.Add(this.btnMove_Loader);
            this.groupBox28.Controls.Add(this.label131);
            this.groupBox28.Controls.Add(this.label132);
            this.groupBox28.Controls.Add(this.txtLHLoader_TargetSpeed);
            this.groupBox28.Controls.Add(this.label133);
            this.groupBox28.Controls.Add(this.txtLHLoader_Targetposition);
            this.groupBox28.Controls.Add(this.label134);
            this.groupBox28.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox28.Location = new System.Drawing.Point(247, 149);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(205, 168);
            this.groupBox28.TabIndex = 56;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Motion Control";
            // 
            // btnMove_Stop_Loader
            // 
            this.btnMove_Stop_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMove_Stop_Loader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove_Stop_Loader.ForeColor = System.Drawing.Color.White;
            this.btnMove_Stop_Loader.Location = new System.Drawing.Point(111, 111);
            this.btnMove_Stop_Loader.Name = "btnMove_Stop_Loader";
            this.btnMove_Stop_Loader.Size = new System.Drawing.Size(83, 38);
            this.btnMove_Stop_Loader.TabIndex = 72;
            this.btnMove_Stop_Loader.Text = "Stop";
            this.btnMove_Stop_Loader.UseVisualStyleBackColor = false;
            // 
            // btnMove_Loader
            // 
            this.btnMove_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMove_Loader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove_Loader.ForeColor = System.Drawing.Color.White;
            this.btnMove_Loader.Location = new System.Drawing.Point(15, 111);
            this.btnMove_Loader.Name = "btnMove_Loader";
            this.btnMove_Loader.Size = new System.Drawing.Size(83, 38);
            this.btnMove_Loader.TabIndex = 70;
            this.btnMove_Loader.Text = "Move";
            this.btnMove_Loader.UseVisualStyleBackColor = false;
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.Location = new System.Drawing.Point(148, 79);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(47, 14);
            this.label131.TabIndex = 67;
            this.label131.Text = "(mm/s)";
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.Location = new System.Drawing.Point(148, 37);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(37, 14);
            this.label132.TabIndex = 66;
            this.label132.Text = "(mm)";
            // 
            // txtLHLoader_TargetSpeed
            // 
            this.txtLHLoader_TargetSpeed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLHLoader_TargetSpeed.Location = new System.Drawing.Point(75, 66);
            this.txtLHLoader_TargetSpeed.Name = "txtLHLoader_TargetSpeed";
            this.txtLHLoader_TargetSpeed.Size = new System.Drawing.Size(67, 26);
            this.txtLHLoader_TargetSpeed.TabIndex = 61;
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.Location = new System.Drawing.Point(14, 73);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(45, 14);
            this.label133.TabIndex = 60;
            this.label133.Text = "Speed";
            // 
            // txtLHLoader_Targetposition
            // 
            this.txtLHLoader_Targetposition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLHLoader_Targetposition.Location = new System.Drawing.Point(75, 29);
            this.txtLHLoader_Targetposition.Name = "txtLHLoader_Targetposition";
            this.txtLHLoader_Targetposition.Size = new System.Drawing.Size(67, 26);
            this.txtLHLoader_Targetposition.TabIndex = 59;
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.Location = new System.Drawing.Point(14, 36);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(57, 14);
            this.label134.TabIndex = 37;
            this.label134.Text = "Position";
            // 
            // groupBox29
            // 
            this.groupBox29.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox29.Controls.Add(this.lblServoDisableloader);
            this.groupBox29.Controls.Add(this.label188);
            this.groupBox29.Controls.Add(this.lblServoloader_Error);
            this.groupBox29.Controls.Add(this.label158);
            this.groupBox29.Controls.Add(this.lblServoloader_PositiveLimit);
            this.groupBox29.Controls.Add(this.label138);
            this.groupBox29.Controls.Add(this.lblServoloader_Home);
            this.groupBox29.Controls.Add(this.lblServoloader_Running);
            this.groupBox29.Controls.Add(this.lblServoloader_Ready);
            this.groupBox29.Controls.Add(this.lblServoloader_NegativeLimit);
            this.groupBox29.Controls.Add(this.lblServoloader_Enable);
            this.groupBox29.Controls.Add(this.label146);
            this.groupBox29.Controls.Add(this.label147);
            this.groupBox29.Controls.Add(this.label148);
            this.groupBox29.Controls.Add(this.label149);
            this.groupBox29.Controls.Add(this.label150);
            this.groupBox29.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox29.Location = new System.Drawing.Point(15, 14);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(687, 128);
            this.groupBox29.TabIndex = 37;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Device Status";
            // 
            // lblServoDisableloader
            // 
            this.lblServoDisableloader.BackColor = System.Drawing.Color.Maroon;
            this.lblServoDisableloader.Location = new System.Drawing.Point(103, 87);
            this.lblServoDisableloader.Name = "lblServoDisableloader";
            this.lblServoDisableloader.Size = new System.Drawing.Size(27, 26);
            this.lblServoDisableloader.TabIndex = 63;
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label188.Location = new System.Drawing.Point(16, 94);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(89, 14);
            this.label188.TabIndex = 62;
            this.label188.Text = "Servo Disable";
            // 
            // lblServoloader_Error
            // 
            this.lblServoloader_Error.BackColor = System.Drawing.Color.Maroon;
            this.lblServoloader_Error.Location = new System.Drawing.Point(459, 90);
            this.lblServoloader_Error.Name = "lblServoloader_Error";
            this.lblServoloader_Error.Size = new System.Drawing.Size(27, 26);
            this.lblServoloader_Error.TabIndex = 61;
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label158.Location = new System.Drawing.Point(364, 98);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(93, 14);
            this.label158.TabIndex = 60;
            this.label158.Text = "Servo In Error";
            // 
            // lblServoloader_PositiveLimit
            // 
            this.lblServoloader_PositiveLimit.BackColor = System.Drawing.Color.Maroon;
            this.lblServoloader_PositiveLimit.Location = new System.Drawing.Point(653, 87);
            this.lblServoloader_PositiveLimit.Name = "lblServoloader_PositiveLimit";
            this.lblServoloader_PositiveLimit.Size = new System.Drawing.Size(27, 26);
            this.lblServoloader_PositiveLimit.TabIndex = 59;
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.Location = new System.Drawing.Point(560, 94);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(89, 14);
            this.label138.TabIndex = 56;
            this.label138.Text = "Positive Limit";
            // 
            // lblServoloader_Home
            // 
            this.lblServoloader_Home.BackColor = System.Drawing.Color.Maroon;
            this.lblServoloader_Home.Location = new System.Drawing.Point(459, 36);
            this.lblServoloader_Home.Name = "lblServoloader_Home";
            this.lblServoloader_Home.Size = new System.Drawing.Size(27, 26);
            this.lblServoloader_Home.TabIndex = 48;
            // 
            // lblServoloader_Running
            // 
            this.lblServoloader_Running.BackColor = System.Drawing.Color.Maroon;
            this.lblServoloader_Running.Location = new System.Drawing.Point(285, 87);
            this.lblServoloader_Running.Name = "lblServoloader_Running";
            this.lblServoloader_Running.Size = new System.Drawing.Size(27, 26);
            this.lblServoloader_Running.TabIndex = 47;
            // 
            // lblServoloader_Ready
            // 
            this.lblServoloader_Ready.BackColor = System.Drawing.Color.Maroon;
            this.lblServoloader_Ready.Location = new System.Drawing.Point(285, 33);
            this.lblServoloader_Ready.Name = "lblServoloader_Ready";
            this.lblServoloader_Ready.Size = new System.Drawing.Size(27, 26);
            this.lblServoloader_Ready.TabIndex = 46;
            // 
            // lblServoloader_NegativeLimit
            // 
            this.lblServoloader_NegativeLimit.BackColor = System.Drawing.Color.Maroon;
            this.lblServoloader_NegativeLimit.Location = new System.Drawing.Point(653, 33);
            this.lblServoloader_NegativeLimit.Name = "lblServoloader_NegativeLimit";
            this.lblServoloader_NegativeLimit.Size = new System.Drawing.Size(27, 26);
            this.lblServoloader_NegativeLimit.TabIndex = 45;
            // 
            // lblServoloader_Enable
            // 
            this.lblServoloader_Enable.BackColor = System.Drawing.Color.Maroon;
            this.lblServoloader_Enable.Location = new System.Drawing.Point(103, 33);
            this.lblServoloader_Enable.Name = "lblServoloader_Enable";
            this.lblServoloader_Enable.Size = new System.Drawing.Size(27, 26);
            this.lblServoloader_Enable.TabIndex = 45;
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.Location = new System.Drawing.Point(184, 94);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(98, 14);
            this.label146.TabIndex = 43;
            this.label146.Text = "Servo Running";
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label147.Location = new System.Drawing.Point(376, 44);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(81, 14);
            this.label147.TabIndex = 41;
            this.label147.Text = "Servo Home";
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.Location = new System.Drawing.Point(555, 41);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(94, 14);
            this.label148.TabIndex = 37;
            this.label148.Text = "Negative Limit";
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.Location = new System.Drawing.Point(199, 41);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(84, 14);
            this.label149.TabIndex = 39;
            this.label149.Text = "Servo Ready";
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.Location = new System.Drawing.Point(16, 41);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(86, 14);
            this.label150.TabIndex = 37;
            this.label150.Text = "Servo Enable";
            // 
            // Unloader
            // 
            this.Unloader.BackColor = System.Drawing.Color.LightGray;
            this.Unloader.Controls.Add(this.groupBox30);
            this.Unloader.Location = new System.Drawing.Point(4, 27);
            this.Unloader.Name = "Unloader";
            this.Unloader.Padding = new System.Windows.Forms.Padding(3);
            this.Unloader.Size = new System.Drawing.Size(1561, 601);
            this.Unloader.TabIndex = 1;
            this.Unloader.Text = "Unloader";
            // 
            // groupBox30
            // 
            this.groupBox30.BackColor = System.Drawing.Color.White;
            this.groupBox30.Controls.Add(this.groupBox53);
            this.groupBox30.Controls.Add(this.groupBox54);
            this.groupBox30.Controls.Add(this.groupBox55);
            this.groupBox30.Controls.Add(this.groupBox56);
            this.groupBox30.Controls.Add(this.groupBox57);
            this.groupBox30.Controls.Add(this.groupBox58);
            this.groupBox30.Controls.Add(this.groupBox59);
            this.groupBox30.Controls.Add(this.groupBox60);
            this.groupBox30.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox30.Location = new System.Drawing.Point(239, 47);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(1053, 485);
            this.groupBox30.TabIndex = 40;
            this.groupBox30.TabStop = false;
            // 
            // groupBox53
            // 
            this.groupBox53.Controls.Add(this.btnUnloader_BreakEnable);
            this.groupBox53.Controls.Add(this.btnUnloader_BreakDisable);
            this.groupBox53.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox53.Location = new System.Drawing.Point(15, 330);
            this.groupBox53.Name = "groupBox53";
            this.groupBox53.Size = new System.Drawing.Size(177, 144);
            this.groupBox53.TabIndex = 76;
            this.groupBox53.TabStop = false;
            this.groupBox53.Text = "Break Control";
            // 
            // btnUnloader_BreakEnable
            // 
            this.btnUnloader_BreakEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_BreakEnable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_BreakEnable.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_BreakEnable.Location = new System.Drawing.Point(9, 34);
            this.btnUnloader_BreakEnable.Name = "btnUnloader_BreakEnable";
            this.btnUnloader_BreakEnable.Size = new System.Drawing.Size(147, 38);
            this.btnUnloader_BreakEnable.TabIndex = 71;
            this.btnUnloader_BreakEnable.Text = "Break Enable";
            this.btnUnloader_BreakEnable.UseVisualStyleBackColor = false;
            // 
            // btnUnloader_BreakDisable
            // 
            this.btnUnloader_BreakDisable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_BreakDisable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_BreakDisable.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_BreakDisable.Location = new System.Drawing.Point(9, 85);
            this.btnUnloader_BreakDisable.Name = "btnUnloader_BreakDisable";
            this.btnUnloader_BreakDisable.Size = new System.Drawing.Size(147, 38);
            this.btnUnloader_BreakDisable.TabIndex = 71;
            this.btnUnloader_BreakDisable.Text = "Break Disable";
            this.btnUnloader_BreakDisable.UseVisualStyleBackColor = false;
            // 
            // groupBox54
            // 
            this.groupBox54.Controls.Add(this.btnUnloader_ServoEnable);
            this.groupBox54.Controls.Add(this.btnUnloader_ServoClearErr);
            this.groupBox54.Controls.Add(this.btnUnloader_ServoDisable);
            this.groupBox54.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox54.Location = new System.Drawing.Point(15, 149);
            this.groupBox54.Name = "groupBox54";
            this.groupBox54.Size = new System.Drawing.Size(177, 168);
            this.groupBox54.TabIndex = 75;
            this.groupBox54.TabStop = false;
            this.groupBox54.Text = "Device Control";
            // 
            // btnUnloader_ServoEnable
            // 
            this.btnUnloader_ServoEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_ServoEnable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_ServoEnable.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_ServoEnable.Location = new System.Drawing.Point(11, 26);
            this.btnUnloader_ServoEnable.Name = "btnUnloader_ServoEnable";
            this.btnUnloader_ServoEnable.Size = new System.Drawing.Size(147, 38);
            this.btnUnloader_ServoEnable.TabIndex = 71;
            this.btnUnloader_ServoEnable.Text = "Servo Enable";
            this.btnUnloader_ServoEnable.UseVisualStyleBackColor = false;
            // 
            // btnUnloader_ServoClearErr
            // 
            this.btnUnloader_ServoClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_ServoClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_ServoClearErr.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_ServoClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnUnloader_ServoClearErr.Name = "btnUnloader_ServoClearErr";
            this.btnUnloader_ServoClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnUnloader_ServoClearErr.TabIndex = 71;
            this.btnUnloader_ServoClearErr.Text = "Servo Clear Error";
            this.btnUnloader_ServoClearErr.UseVisualStyleBackColor = false;
            // 
            // btnUnloader_ServoDisable
            // 
            this.btnUnloader_ServoDisable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_ServoDisable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_ServoDisable.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_ServoDisable.Location = new System.Drawing.Point(11, 70);
            this.btnUnloader_ServoDisable.Name = "btnUnloader_ServoDisable";
            this.btnUnloader_ServoDisable.Size = new System.Drawing.Size(147, 38);
            this.btnUnloader_ServoDisable.TabIndex = 71;
            this.btnUnloader_ServoDisable.Text = "Servo Disable";
            this.btnUnloader_ServoDisable.UseVisualStyleBackColor = false;
            // 
            // groupBox55
            // 
            this.groupBox55.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox55.Controls.Add(this.label151);
            this.groupBox55.Controls.Add(this.lblUnloader_ActualPosition);
            this.groupBox55.Controls.Add(this.label153);
            this.groupBox55.Controls.Add(this.label156);
            this.groupBox55.Controls.Add(this.label157);
            this.groupBox55.Controls.Add(this.lblUnloader_ActualVelocity);
            this.groupBox55.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox55.Location = new System.Drawing.Point(732, 14);
            this.groupBox55.Name = "groupBox55";
            this.groupBox55.Size = new System.Drawing.Size(297, 128);
            this.groupBox55.TabIndex = 74;
            this.groupBox55.TabStop = false;
            this.groupBox55.Text = "Live Values";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.Location = new System.Drawing.Point(247, 81);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(47, 14);
            this.label151.TabIndex = 73;
            this.label151.Text = "(mm/s)";
            // 
            // lblUnloader_ActualPosition
            // 
            this.lblUnloader_ActualPosition.AutoSize = true;
            this.lblUnloader_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUnloader_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnloader_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnloader_ActualPosition.Location = new System.Drawing.Point(167, 47);
            this.lblUnloader_ActualPosition.Name = "lblUnloader_ActualPosition";
            this.lblUnloader_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lblUnloader_ActualPosition.TabIndex = 53;
            this.lblUnloader_ActualPosition.Text = "0";
            this.lblUnloader_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label153.Location = new System.Drawing.Point(247, 47);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(37, 14);
            this.label153.TabIndex = 75;
            this.label153.Text = "(mm)";
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label156.Location = new System.Drawing.Point(10, 47);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(139, 14);
            this.label156.TabIndex = 52;
            this.label156.Text = "Servo Actual Position";
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(10, 81);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(137, 14);
            this.label157.TabIndex = 54;
            this.label157.Text = "Servo Actual Velocity";
            // 
            // lblUnloader_ActualVelocity
            // 
            this.lblUnloader_ActualVelocity.AutoSize = true;
            this.lblUnloader_ActualVelocity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUnloader_ActualVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnloader_ActualVelocity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnloader_ActualVelocity.Location = new System.Drawing.Point(167, 81);
            this.lblUnloader_ActualVelocity.Name = "lblUnloader_ActualVelocity";
            this.lblUnloader_ActualVelocity.Size = new System.Drawing.Size(18, 16);
            this.lblUnloader_ActualVelocity.TabIndex = 55;
            this.lblUnloader_ActualVelocity.Text = "0";
            this.lblUnloader_ActualVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox56
            // 
            this.groupBox56.Controls.Add(this.btnUnloader_Stop);
            this.groupBox56.Controls.Add(this.btnUnloader_Move_point);
            this.groupBox56.Controls.Add(this.textBox34);
            this.groupBox56.Controls.Add(this.textBox35);
            this.groupBox56.Controls.Add(this.textBox36);
            this.groupBox56.Controls.Add(this.label248);
            this.groupBox56.Controls.Add(this.label249);
            this.groupBox56.Controls.Add(this.textBox46);
            this.groupBox56.Controls.Add(this.label250);
            this.groupBox56.Controls.Add(this.textBox47);
            this.groupBox56.Controls.Add(this.label251);
            this.groupBox56.Controls.Add(this.label252);
            this.groupBox56.Controls.Add(this.label253);
            this.groupBox56.Controls.Add(this.label254);
            this.groupBox56.Controls.Add(this.label255);
            this.groupBox56.Controls.Add(this.label256);
            this.groupBox56.Controls.Add(this.label257);
            this.groupBox56.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox56.Location = new System.Drawing.Point(247, 326);
            this.groupBox56.Name = "groupBox56";
            this.groupBox56.Size = new System.Drawing.Size(781, 149);
            this.groupBox56.TabIndex = 73;
            this.groupBox56.TabStop = false;
            this.groupBox56.Text = "Point To Point Control";
            // 
            // btnUnloader_Stop
            // 
            this.btnUnloader_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_Stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_Stop.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_Stop.Location = new System.Drawing.Point(399, 103);
            this.btnUnloader_Stop.Name = "btnUnloader_Stop";
            this.btnUnloader_Stop.Size = new System.Drawing.Size(83, 38);
            this.btnUnloader_Stop.TabIndex = 71;
            this.btnUnloader_Stop.Text = "Stop";
            this.btnUnloader_Stop.UseVisualStyleBackColor = false;
            // 
            // btnUnloader_Move_point
            // 
            this.btnUnloader_Move_point.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_Move_point.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_Move_point.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_Move_point.Location = new System.Drawing.Point(203, 103);
            this.btnUnloader_Move_point.Name = "btnUnloader_Move_point";
            this.btnUnloader_Move_point.Size = new System.Drawing.Size(83, 38);
            this.btnUnloader_Move_point.TabIndex = 70;
            this.btnUnloader_Move_point.Text = "Move";
            this.btnUnloader_Move_point.UseVisualStyleBackColor = false;
            // 
            // textBox34
            // 
            this.textBox34.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox34.Location = new System.Drawing.Point(603, 28);
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(67, 26);
            this.textBox34.TabIndex = 61;
            // 
            // textBox35
            // 
            this.textBox35.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox35.Location = new System.Drawing.Point(336, 65);
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new System.Drawing.Size(67, 26);
            this.textBox35.TabIndex = 61;
            // 
            // textBox36
            // 
            this.textBox36.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox36.Location = new System.Drawing.Point(336, 28);
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(67, 26);
            this.textBox36.TabIndex = 61;
            // 
            // label248
            // 
            this.label248.AutoSize = true;
            this.label248.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label248.Location = new System.Drawing.Point(21, 80);
            this.label248.Name = "label248";
            this.label248.Size = new System.Drawing.Size(84, 14);
            this.label248.TabIndex = 37;
            this.label248.Text = "End Position";
            // 
            // label249
            // 
            this.label249.AutoSize = true;
            this.label249.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label249.Location = new System.Drawing.Point(14, 40);
            this.label249.Name = "label249";
            this.label249.Size = new System.Drawing.Size(93, 14);
            this.label249.TabIndex = 37;
            this.label249.Text = "Start Position";
            // 
            // textBox46
            // 
            this.textBox46.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox46.Location = new System.Drawing.Point(105, 71);
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new System.Drawing.Size(67, 26);
            this.textBox46.TabIndex = 59;
            // 
            // label250
            // 
            this.label250.AutoSize = true;
            this.label250.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label250.Location = new System.Drawing.Point(539, 40);
            this.label250.Name = "label250";
            this.label250.Size = new System.Drawing.Size(62, 14);
            this.label250.TabIndex = 60;
            this.label250.Text = "Iteration";
            // 
            // textBox47
            // 
            this.textBox47.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox47.Location = new System.Drawing.Point(105, 32);
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new System.Drawing.Size(67, 26);
            this.textBox47.TabIndex = 59;
            // 
            // label251
            // 
            this.label251.AutoSize = true;
            this.label251.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label251.Location = new System.Drawing.Point(297, 76);
            this.label251.Name = "label251";
            this.label251.Size = new System.Drawing.Size(35, 14);
            this.label251.TabIndex = 60;
            this.label251.Text = "Wait";
            // 
            // label252
            // 
            this.label252.AutoSize = true;
            this.label252.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label252.Location = new System.Drawing.Point(179, 80);
            this.label252.Name = "label252";
            this.label252.Size = new System.Drawing.Size(37, 14);
            this.label252.TabIndex = 66;
            this.label252.Text = "(mm)";
            // 
            // label253
            // 
            this.label253.AutoSize = true;
            this.label253.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label253.Location = new System.Drawing.Point(676, 40);
            this.label253.Name = "label253";
            this.label253.Size = new System.Drawing.Size(39, 14);
            this.label253.TabIndex = 67;
            this.label253.Text = "count";
            // 
            // label254
            // 
            this.label254.AutoSize = true;
            this.label254.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label254.Location = new System.Drawing.Point(287, 40);
            this.label254.Name = "label254";
            this.label254.Size = new System.Drawing.Size(45, 14);
            this.label254.TabIndex = 60;
            this.label254.Text = "Speed";
            // 
            // label255
            // 
            this.label255.AutoSize = true;
            this.label255.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label255.Location = new System.Drawing.Point(410, 76);
            this.label255.Name = "label255";
            this.label255.Size = new System.Drawing.Size(25, 14);
            this.label255.TabIndex = 67;
            this.label255.Text = "sec";
            // 
            // label256
            // 
            this.label256.AutoSize = true;
            this.label256.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label256.Location = new System.Drawing.Point(179, 40);
            this.label256.Name = "label256";
            this.label256.Size = new System.Drawing.Size(37, 14);
            this.label256.TabIndex = 66;
            this.label256.Text = "(mm)";
            // 
            // label257
            // 
            this.label257.AutoSize = true;
            this.label257.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label257.Location = new System.Drawing.Point(410, 40);
            this.label257.Name = "label257";
            this.label257.Size = new System.Drawing.Size(47, 14);
            this.label257.TabIndex = 67;
            this.label257.Text = "(mm/s)";
            // 
            // groupBox57
            // 
            this.groupBox57.BackColor = System.Drawing.Color.White;
            this.groupBox57.Controls.Add(this.txtJogVelocity_LHUnloader);
            this.groupBox57.Controls.Add(this.label258);
            this.groupBox57.Controls.Add(this.txtJogDist_LHUnloader);
            this.groupBox57.Controls.Add(this.label259);
            this.groupBox57.Controls.Add(this.label260);
            this.groupBox57.Controls.Add(this.btnJogDec_Unloader);
            this.groupBox57.Controls.Add(this.btnJogAdd_Unloader);
            this.groupBox57.Controls.Add(this.label261);
            this.groupBox57.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox57.Location = new System.Drawing.Point(795, 149);
            this.groupBox57.Name = "groupBox57";
            this.groupBox57.Size = new System.Drawing.Size(234, 168);
            this.groupBox57.TabIndex = 72;
            this.groupBox57.TabStop = false;
            this.groupBox57.Text = "Jog Control";
            // 
            // txtJogVelocity_LHUnloader
            // 
            this.txtJogVelocity_LHUnloader.FormattingEnabled = true;
            this.txtJogVelocity_LHUnloader.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.txtJogVelocity_LHUnloader.Location = new System.Drawing.Point(105, 64);
            this.txtJogVelocity_LHUnloader.Name = "txtJogVelocity_LHUnloader";
            this.txtJogVelocity_LHUnloader.Size = new System.Drawing.Size(67, 26);
            this.txtJogVelocity_LHUnloader.TabIndex = 78;
            // 
            // label258
            // 
            this.label258.AutoSize = true;
            this.label258.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label258.Location = new System.Drawing.Point(176, 41);
            this.label258.Name = "label258";
            this.label258.Size = new System.Drawing.Size(37, 14);
            this.label258.TabIndex = 77;
            this.label258.Text = "(mm)";
            // 
            // txtJogDist_LHUnloader
            // 
            this.txtJogDist_LHUnloader.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJogDist_LHUnloader.Location = new System.Drawing.Point(105, 32);
            this.txtJogDist_LHUnloader.Name = "txtJogDist_LHUnloader";
            this.txtJogDist_LHUnloader.Size = new System.Drawing.Size(67, 26);
            this.txtJogDist_LHUnloader.TabIndex = 76;
            // 
            // label259
            // 
            this.label259.AutoSize = true;
            this.label259.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label259.Location = new System.Drawing.Point(20, 40);
            this.label259.Name = "label259";
            this.label259.Size = new System.Drawing.Size(83, 14);
            this.label259.TabIndex = 75;
            this.label259.Text = "Jog Position";
            // 
            // label260
            // 
            this.label260.AutoSize = true;
            this.label260.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label260.Location = new System.Drawing.Point(172, 71);
            this.label260.Name = "label260";
            this.label260.Size = new System.Drawing.Size(47, 14);
            this.label260.TabIndex = 73;
            this.label260.Text = "(mm/s)";
            // 
            // btnJogDec_Unloader
            // 
            this.btnJogDec_Unloader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogDec_Unloader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogDec_Unloader.ForeColor = System.Drawing.Color.White;
            this.btnJogDec_Unloader.Location = new System.Drawing.Point(123, 107);
            this.btnJogDec_Unloader.Name = "btnJogDec_Unloader";
            this.btnJogDec_Unloader.Size = new System.Drawing.Size(83, 38);
            this.btnJogDec_Unloader.TabIndex = 74;
            this.btnJogDec_Unloader.Text = "Jog -";
            this.btnJogDec_Unloader.UseVisualStyleBackColor = false;
            // 
            // btnJogAdd_Unloader
            // 
            this.btnJogAdd_Unloader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogAdd_Unloader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogAdd_Unloader.ForeColor = System.Drawing.Color.White;
            this.btnJogAdd_Unloader.Location = new System.Drawing.Point(24, 107);
            this.btnJogAdd_Unloader.Name = "btnJogAdd_Unloader";
            this.btnJogAdd_Unloader.Size = new System.Drawing.Size(83, 38);
            this.btnJogAdd_Unloader.TabIndex = 73;
            this.btnJogAdd_Unloader.Text = "Jog +";
            this.btnJogAdd_Unloader.UseVisualStyleBackColor = false;
            // 
            // label261
            // 
            this.label261.AutoSize = true;
            this.label261.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label261.Location = new System.Drawing.Point(20, 72);
            this.label261.Name = "label261";
            this.label261.Size = new System.Drawing.Size(81, 14);
            this.label261.TabIndex = 37;
            this.label261.Text = "Jog Velocity";
            // 
            // groupBox58
            // 
            this.groupBox58.BackColor = System.Drawing.Color.White;
            this.groupBox58.Controls.Add(this.btnUnloader_Home_Stop);
            this.groupBox58.Controls.Add(this.label262);
            this.groupBox58.Controls.Add(this.btnUnloader_Home);
            this.groupBox58.Controls.Add(this.textBox49);
            this.groupBox58.Controls.Add(this.label263);
            this.groupBox58.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox58.Location = new System.Drawing.Point(507, 153);
            this.groupBox58.Name = "groupBox58";
            this.groupBox58.Size = new System.Drawing.Size(234, 168);
            this.groupBox58.TabIndex = 71;
            this.groupBox58.TabStop = false;
            this.groupBox58.Text = "Homing Control";
            // 
            // btnUnloader_Home_Stop
            // 
            this.btnUnloader_Home_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_Home_Stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_Home_Stop.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_Home_Stop.Location = new System.Drawing.Point(125, 105);
            this.btnUnloader_Home_Stop.Name = "btnUnloader_Home_Stop";
            this.btnUnloader_Home_Stop.Size = new System.Drawing.Size(83, 38);
            this.btnUnloader_Home_Stop.TabIndex = 73;
            this.btnUnloader_Home_Stop.Text = "Stop";
            this.btnUnloader_Home_Stop.UseVisualStyleBackColor = false;
            // 
            // label262
            // 
            this.label262.AutoSize = true;
            this.label262.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label262.Location = new System.Drawing.Point(179, 55);
            this.label262.Name = "label262";
            this.label262.Size = new System.Drawing.Size(47, 14);
            this.label262.TabIndex = 72;
            this.label262.Text = "(mm/s)";
            // 
            // btnUnloader_Home
            // 
            this.btnUnloader_Home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_Home.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_Home.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_Home.Location = new System.Drawing.Point(19, 105);
            this.btnUnloader_Home.Name = "btnUnloader_Home";
            this.btnUnloader_Home.Size = new System.Drawing.Size(83, 38);
            this.btnUnloader_Home.TabIndex = 72;
            this.btnUnloader_Home.Text = "Home";
            this.btnUnloader_Home.UseVisualStyleBackColor = false;
            // 
            // textBox49
            // 
            this.textBox49.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox49.Location = new System.Drawing.Point(108, 47);
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new System.Drawing.Size(67, 26);
            this.textBox49.TabIndex = 59;
            // 
            // label263
            // 
            this.label263.AutoSize = true;
            this.label263.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label263.Location = new System.Drawing.Point(9, 55);
            this.label263.Name = "label263";
            this.label263.Size = new System.Drawing.Size(94, 14);
            this.label263.TabIndex = 37;
            this.label263.Text = "Home Velocity";
            // 
            // groupBox59
            // 
            this.groupBox59.BackColor = System.Drawing.Color.White;
            this.groupBox59.Controls.Add(this.btnUnloader_Stop_Move);
            this.groupBox59.Controls.Add(this.btnUnloader_Move);
            this.groupBox59.Controls.Add(this.label264);
            this.groupBox59.Controls.Add(this.label265);
            this.groupBox59.Controls.Add(this.txtLHUnLoader_TargetSpeed);
            this.groupBox59.Controls.Add(this.label266);
            this.groupBox59.Controls.Add(this.txtLHUnLoader_Targetposition);
            this.groupBox59.Controls.Add(this.label267);
            this.groupBox59.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox59.Location = new System.Drawing.Point(247, 149);
            this.groupBox59.Name = "groupBox59";
            this.groupBox59.Size = new System.Drawing.Size(205, 168);
            this.groupBox59.TabIndex = 56;
            this.groupBox59.TabStop = false;
            this.groupBox59.Text = "Motion Control";
            // 
            // btnUnloader_Stop_Move
            // 
            this.btnUnloader_Stop_Move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_Stop_Move.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_Stop_Move.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_Stop_Move.Location = new System.Drawing.Point(111, 107);
            this.btnUnloader_Stop_Move.Name = "btnUnloader_Stop_Move";
            this.btnUnloader_Stop_Move.Size = new System.Drawing.Size(83, 38);
            this.btnUnloader_Stop_Move.TabIndex = 72;
            this.btnUnloader_Stop_Move.Text = "Stop";
            this.btnUnloader_Stop_Move.UseVisualStyleBackColor = false;
            // 
            // btnUnloader_Move
            // 
            this.btnUnloader_Move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnUnloader_Move.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnloader_Move.ForeColor = System.Drawing.Color.White;
            this.btnUnloader_Move.Location = new System.Drawing.Point(15, 107);
            this.btnUnloader_Move.Name = "btnUnloader_Move";
            this.btnUnloader_Move.Size = new System.Drawing.Size(83, 38);
            this.btnUnloader_Move.TabIndex = 70;
            this.btnUnloader_Move.Text = "Move";
            this.btnUnloader_Move.UseVisualStyleBackColor = false;
            // 
            // label264
            // 
            this.label264.AutoSize = true;
            this.label264.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label264.Location = new System.Drawing.Point(148, 79);
            this.label264.Name = "label264";
            this.label264.Size = new System.Drawing.Size(47, 14);
            this.label264.TabIndex = 67;
            this.label264.Text = "(mm/s)";
            // 
            // label265
            // 
            this.label265.AutoSize = true;
            this.label265.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label265.Location = new System.Drawing.Point(148, 37);
            this.label265.Name = "label265";
            this.label265.Size = new System.Drawing.Size(37, 14);
            this.label265.TabIndex = 66;
            this.label265.Text = "(mm)";
            // 
            // txtLHUnLoader_TargetSpeed
            // 
            this.txtLHUnLoader_TargetSpeed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLHUnLoader_TargetSpeed.Location = new System.Drawing.Point(75, 66);
            this.txtLHUnLoader_TargetSpeed.Name = "txtLHUnLoader_TargetSpeed";
            this.txtLHUnLoader_TargetSpeed.Size = new System.Drawing.Size(67, 26);
            this.txtLHUnLoader_TargetSpeed.TabIndex = 61;
            // 
            // label266
            // 
            this.label266.AutoSize = true;
            this.label266.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label266.Location = new System.Drawing.Point(14, 73);
            this.label266.Name = "label266";
            this.label266.Size = new System.Drawing.Size(45, 14);
            this.label266.TabIndex = 60;
            this.label266.Text = "Speed";
            // 
            // txtLHUnLoader_Targetposition
            // 
            this.txtLHUnLoader_Targetposition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLHUnLoader_Targetposition.Location = new System.Drawing.Point(75, 29);
            this.txtLHUnLoader_Targetposition.Name = "txtLHUnLoader_Targetposition";
            this.txtLHUnLoader_Targetposition.Size = new System.Drawing.Size(67, 26);
            this.txtLHUnLoader_Targetposition.TabIndex = 59;
            // 
            // label267
            // 
            this.label267.AutoSize = true;
            this.label267.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label267.Location = new System.Drawing.Point(14, 36);
            this.label267.Name = "label267";
            this.label267.Size = new System.Drawing.Size(57, 14);
            this.label267.TabIndex = 37;
            this.label267.Text = "Position";
            // 
            // groupBox60
            // 
            this.groupBox60.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox60.Controls.Add(this.lblServoDisableUnloader);
            this.groupBox60.Controls.Add(this.label242);
            this.groupBox60.Controls.Add(this.lblUnloader_Error);
            this.groupBox60.Controls.Add(this.label270);
            this.groupBox60.Controls.Add(this.lblUnloader_PositiveLimit);
            this.groupBox60.Controls.Add(this.label271);
            this.groupBox60.Controls.Add(this.lblUnloader_Home);
            this.groupBox60.Controls.Add(this.lblUnloader_Running);
            this.groupBox60.Controls.Add(this.lblUnloader_Ready);
            this.groupBox60.Controls.Add(this.lblUnloader_NegativeLimit);
            this.groupBox60.Controls.Add(this.lblUnloader_Enable);
            this.groupBox60.Controls.Add(this.label279);
            this.groupBox60.Controls.Add(this.label280);
            this.groupBox60.Controls.Add(this.label281);
            this.groupBox60.Controls.Add(this.label282);
            this.groupBox60.Controls.Add(this.label283);
            this.groupBox60.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox60.Location = new System.Drawing.Point(15, 14);
            this.groupBox60.Name = "groupBox60";
            this.groupBox60.Size = new System.Drawing.Size(687, 128);
            this.groupBox60.TabIndex = 37;
            this.groupBox60.TabStop = false;
            this.groupBox60.Text = "Device Status";
            // 
            // lblServoDisableUnloader
            // 
            this.lblServoDisableUnloader.BackColor = System.Drawing.Color.Maroon;
            this.lblServoDisableUnloader.Location = new System.Drawing.Point(103, 87);
            this.lblServoDisableUnloader.Name = "lblServoDisableUnloader";
            this.lblServoDisableUnloader.Size = new System.Drawing.Size(27, 26);
            this.lblServoDisableUnloader.TabIndex = 63;
            // 
            // label242
            // 
            this.label242.AutoSize = true;
            this.label242.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label242.Location = new System.Drawing.Point(16, 94);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(89, 14);
            this.label242.TabIndex = 62;
            this.label242.Text = "Servo Disable";
            // 
            // lblUnloader_Error
            // 
            this.lblUnloader_Error.BackColor = System.Drawing.Color.Maroon;
            this.lblUnloader_Error.Location = new System.Drawing.Point(459, 87);
            this.lblUnloader_Error.Name = "lblUnloader_Error";
            this.lblUnloader_Error.Size = new System.Drawing.Size(27, 26);
            this.lblUnloader_Error.TabIndex = 61;
            // 
            // label270
            // 
            this.label270.AutoSize = true;
            this.label270.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label270.Location = new System.Drawing.Point(364, 94);
            this.label270.Name = "label270";
            this.label270.Size = new System.Drawing.Size(93, 14);
            this.label270.TabIndex = 60;
            this.label270.Text = "Servo In Error";
            // 
            // lblUnloader_PositiveLimit
            // 
            this.lblUnloader_PositiveLimit.BackColor = System.Drawing.Color.Maroon;
            this.lblUnloader_PositiveLimit.Location = new System.Drawing.Point(653, 87);
            this.lblUnloader_PositiveLimit.Name = "lblUnloader_PositiveLimit";
            this.lblUnloader_PositiveLimit.Size = new System.Drawing.Size(27, 26);
            this.lblUnloader_PositiveLimit.TabIndex = 59;
            // 
            // label271
            // 
            this.label271.AutoSize = true;
            this.label271.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label271.Location = new System.Drawing.Point(560, 94);
            this.label271.Name = "label271";
            this.label271.Size = new System.Drawing.Size(89, 14);
            this.label271.TabIndex = 56;
            this.label271.Text = "Positive Limit";
            // 
            // lblUnloader_Home
            // 
            this.lblUnloader_Home.BackColor = System.Drawing.Color.Maroon;
            this.lblUnloader_Home.Location = new System.Drawing.Point(459, 36);
            this.lblUnloader_Home.Name = "lblUnloader_Home";
            this.lblUnloader_Home.Size = new System.Drawing.Size(27, 26);
            this.lblUnloader_Home.TabIndex = 48;
            // 
            // lblUnloader_Running
            // 
            this.lblUnloader_Running.BackColor = System.Drawing.Color.Maroon;
            this.lblUnloader_Running.Location = new System.Drawing.Point(285, 87);
            this.lblUnloader_Running.Name = "lblUnloader_Running";
            this.lblUnloader_Running.Size = new System.Drawing.Size(27, 26);
            this.lblUnloader_Running.TabIndex = 47;
            // 
            // lblUnloader_Ready
            // 
            this.lblUnloader_Ready.BackColor = System.Drawing.Color.Maroon;
            this.lblUnloader_Ready.Location = new System.Drawing.Point(285, 33);
            this.lblUnloader_Ready.Name = "lblUnloader_Ready";
            this.lblUnloader_Ready.Size = new System.Drawing.Size(27, 26);
            this.lblUnloader_Ready.TabIndex = 46;
            // 
            // lblUnloader_NegativeLimit
            // 
            this.lblUnloader_NegativeLimit.BackColor = System.Drawing.Color.Maroon;
            this.lblUnloader_NegativeLimit.Location = new System.Drawing.Point(653, 33);
            this.lblUnloader_NegativeLimit.Name = "lblUnloader_NegativeLimit";
            this.lblUnloader_NegativeLimit.Size = new System.Drawing.Size(27, 26);
            this.lblUnloader_NegativeLimit.TabIndex = 45;
            // 
            // lblUnloader_Enable
            // 
            this.lblUnloader_Enable.BackColor = System.Drawing.Color.Maroon;
            this.lblUnloader_Enable.Location = new System.Drawing.Point(103, 33);
            this.lblUnloader_Enable.Name = "lblUnloader_Enable";
            this.lblUnloader_Enable.Size = new System.Drawing.Size(27, 26);
            this.lblUnloader_Enable.TabIndex = 45;
            // 
            // label279
            // 
            this.label279.AutoSize = true;
            this.label279.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label279.Location = new System.Drawing.Point(184, 94);
            this.label279.Name = "label279";
            this.label279.Size = new System.Drawing.Size(98, 14);
            this.label279.TabIndex = 43;
            this.label279.Text = "Servo Running";
            // 
            // label280
            // 
            this.label280.AutoSize = true;
            this.label280.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label280.Location = new System.Drawing.Point(376, 44);
            this.label280.Name = "label280";
            this.label280.Size = new System.Drawing.Size(81, 14);
            this.label280.TabIndex = 41;
            this.label280.Text = "Servo Home";
            // 
            // label281
            // 
            this.label281.AutoSize = true;
            this.label281.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label281.Location = new System.Drawing.Point(555, 41);
            this.label281.Name = "label281";
            this.label281.Size = new System.Drawing.Size(94, 14);
            this.label281.TabIndex = 37;
            this.label281.Text = "Negative Limit";
            // 
            // label282
            // 
            this.label282.AutoSize = true;
            this.label282.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label282.Location = new System.Drawing.Point(199, 41);
            this.label282.Name = "label282";
            this.label282.Size = new System.Drawing.Size(84, 14);
            this.label282.TabIndex = 39;
            this.label282.Text = "Servo Ready";
            // 
            // label283
            // 
            this.label283.AutoSize = true;
            this.label283.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label283.Location = new System.Drawing.Point(16, 41);
            this.label283.Name = "label283";
            this.label283.Size = new System.Drawing.Size(86, 14);
            this.label283.TabIndex = 37;
            this.label283.Text = "Servo Enable";
            // 
            // Shuttle
            // 
            this.Shuttle.BackColor = System.Drawing.Color.LightGray;
            this.Shuttle.Controls.Add(this.button31);
            this.Shuttle.Controls.Add(this.button30);
            this.Shuttle.Controls.Add(this.label36);
            this.Shuttle.Controls.Add(this.InternalShuttle);
            this.Shuttle.Location = new System.Drawing.Point(4, 27);
            this.Shuttle.Name = "Shuttle";
            this.Shuttle.Size = new System.Drawing.Size(1420, 671);
            this.Shuttle.TabIndex = 3;
            this.Shuttle.Text = "SHUTTLE";
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(1071, 35);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(97, 40);
            this.button31.TabIndex = 85;
            this.button31.Text = "stop";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(951, 35);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(89, 40);
            this.button30.TabIndex = 84;
            this.button30.Text = "shuttle";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(696, 13);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(117, 25);
            this.label36.TabIndex = 83;
            this.label36.Text = "SHUTTLE";
            // 
            // InternalShuttle
            // 
            this.InternalShuttle.Controls.Add(this.Shuttle1);
            this.InternalShuttle.Controls.Add(this.Shuttle2);
            this.InternalShuttle.Location = new System.Drawing.Point(9, 67);
            this.InternalShuttle.Name = "InternalShuttle";
            this.InternalShuttle.SelectedIndex = 0;
            this.InternalShuttle.Size = new System.Drawing.Size(1569, 634);
            this.InternalShuttle.TabIndex = 82;
            // 
            // Shuttle1
            // 
            this.Shuttle1.BackColor = System.Drawing.Color.LightGray;
            this.Shuttle1.Controls.Add(this.groupBox82);
            this.Shuttle1.Location = new System.Drawing.Point(4, 27);
            this.Shuttle1.Name = "Shuttle1";
            this.Shuttle1.Padding = new System.Windows.Forms.Padding(3);
            this.Shuttle1.Size = new System.Drawing.Size(1561, 603);
            this.Shuttle1.TabIndex = 0;
            this.Shuttle1.Text = "Shuttle 1";
            // 
            // groupBox82
            // 
            this.groupBox82.BackColor = System.Drawing.Color.White;
            this.groupBox82.Controls.Add(this.groupBox85);
            this.groupBox82.Controls.Add(this.groupBox87);
            this.groupBox82.Controls.Add(this.groupBox89);
            this.groupBox82.Controls.Add(this.groupBox90);
            this.groupBox82.Controls.Add(this.groupBox91);
            this.groupBox82.Controls.Add(this.groupBox92);
            this.groupBox82.Controls.Add(this.groupBox102);
            this.groupBox82.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox82.Location = new System.Drawing.Point(239, 47);
            this.groupBox82.Name = "groupBox82";
            this.groupBox82.Size = new System.Drawing.Size(1053, 485);
            this.groupBox82.TabIndex = 81;
            this.groupBox82.TabStop = false;
            // 
            // groupBox85
            // 
            this.groupBox85.Controls.Add(this.btnShuttle1Enable);
            this.groupBox85.Controls.Add(this.btnShuttle1ClearErr);
            this.groupBox85.Controls.Add(this.btnShuttle1Disable);
            this.groupBox85.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox85.Location = new System.Drawing.Point(15, 156);
            this.groupBox85.Name = "groupBox85";
            this.groupBox85.Size = new System.Drawing.Size(177, 168);
            this.groupBox85.TabIndex = 75;
            this.groupBox85.TabStop = false;
            this.groupBox85.Text = "Device Control";
            // 
            // btnShuttle1Enable
            // 
            this.btnShuttle1Enable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnShuttle1Enable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShuttle1Enable.ForeColor = System.Drawing.Color.White;
            this.btnShuttle1Enable.Location = new System.Drawing.Point(11, 27);
            this.btnShuttle1Enable.Name = "btnShuttle1Enable";
            this.btnShuttle1Enable.Size = new System.Drawing.Size(147, 38);
            this.btnShuttle1Enable.TabIndex = 72;
            this.btnShuttle1Enable.Text = "Servo Enable";
            this.btnShuttle1Enable.UseVisualStyleBackColor = false;
            // 
            // btnShuttle1ClearErr
            // 
            this.btnShuttle1ClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnShuttle1ClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShuttle1ClearErr.ForeColor = System.Drawing.Color.White;
            this.btnShuttle1ClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnShuttle1ClearErr.Name = "btnShuttle1ClearErr";
            this.btnShuttle1ClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnShuttle1ClearErr.TabIndex = 71;
            this.btnShuttle1ClearErr.Text = "Servo Clear Error";
            this.btnShuttle1ClearErr.UseVisualStyleBackColor = false;
            // 
            // btnShuttle1Disable
            // 
            this.btnShuttle1Disable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnShuttle1Disable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShuttle1Disable.ForeColor = System.Drawing.Color.White;
            this.btnShuttle1Disable.Location = new System.Drawing.Point(11, 70);
            this.btnShuttle1Disable.Name = "btnShuttle1Disable";
            this.btnShuttle1Disable.Size = new System.Drawing.Size(147, 38);
            this.btnShuttle1Disable.TabIndex = 71;
            this.btnShuttle1Disable.Text = "Servo Disable";
            this.btnShuttle1Disable.UseVisualStyleBackColor = false;
            // 
            // groupBox87
            // 
            this.groupBox87.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox87.Controls.Add(this.label32);
            this.groupBox87.Controls.Add(this.lbl_Sh1_ActualPosition);
            this.groupBox87.Controls.Add(this.label356);
            this.groupBox87.Controls.Add(this.label362);
            this.groupBox87.Controls.Add(this.label363);
            this.groupBox87.Controls.Add(this.lbl_Shuttle1_TargetPosition);
            this.groupBox87.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox87.Location = new System.Drawing.Point(732, 14);
            this.groupBox87.Name = "groupBox87";
            this.groupBox87.Size = new System.Drawing.Size(297, 128);
            this.groupBox87.TabIndex = 74;
            this.groupBox87.TabStop = false;
            this.groupBox87.Text = "Live Values";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(232, 81);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(47, 14);
            this.label32.TabIndex = 73;
            this.label32.Text = "(mm/s)";
            // 
            // lbl_Sh1_ActualPosition
            // 
            this.lbl_Sh1_ActualPosition.AutoSize = true;
            this.lbl_Sh1_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Sh1_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Sh1_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sh1_ActualPosition.Location = new System.Drawing.Point(175, 45);
            this.lbl_Sh1_ActualPosition.Name = "lbl_Sh1_ActualPosition";
            this.lbl_Sh1_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_Sh1_ActualPosition.TabIndex = 53;
            this.lbl_Sh1_ActualPosition.Text = "0";
            this.lbl_Sh1_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label356
            // 
            this.label356.AutoSize = true;
            this.label356.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label356.Location = new System.Drawing.Point(232, 45);
            this.label356.Name = "label356";
            this.label356.Size = new System.Drawing.Size(37, 14);
            this.label356.TabIndex = 75;
            this.label356.Text = "(mm)";
            // 
            // label362
            // 
            this.label362.AutoSize = true;
            this.label362.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label362.Location = new System.Drawing.Point(10, 45);
            this.label362.Name = "label362";
            this.label362.Size = new System.Drawing.Size(139, 14);
            this.label362.TabIndex = 52;
            this.label362.Text = "Servo Actual Position";
            // 
            // label363
            // 
            this.label363.AutoSize = true;
            this.label363.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label363.Location = new System.Drawing.Point(10, 81);
            this.label363.Name = "label363";
            this.label363.Size = new System.Drawing.Size(137, 14);
            this.label363.TabIndex = 54;
            this.label363.Text = "Servo Actual Velocity";
            // 
            // lbl_Shuttle1_TargetPosition
            // 
            this.lbl_Shuttle1_TargetPosition.AutoSize = true;
            this.lbl_Shuttle1_TargetPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Shuttle1_TargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Shuttle1_TargetPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Shuttle1_TargetPosition.Location = new System.Drawing.Point(175, 81);
            this.lbl_Shuttle1_TargetPosition.Name = "lbl_Shuttle1_TargetPosition";
            this.lbl_Shuttle1_TargetPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_Shuttle1_TargetPosition.TabIndex = 55;
            this.lbl_Shuttle1_TargetPosition.Text = "0";
            this.lbl_Shuttle1_TargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox89
            // 
            this.groupBox89.Controls.Add(this.btnStopPointS1);
            this.groupBox89.Controls.Add(this.btnMovePointS1);
            this.groupBox89.Controls.Add(this.textBox68);
            this.groupBox89.Controls.Add(this.textBox79);
            this.groupBox89.Controls.Add(this.textBox80);
            this.groupBox89.Controls.Add(this.label387);
            this.groupBox89.Controls.Add(this.label388);
            this.groupBox89.Controls.Add(this.textBox81);
            this.groupBox89.Controls.Add(this.label389);
            this.groupBox89.Controls.Add(this.textBox82);
            this.groupBox89.Controls.Add(this.label392);
            this.groupBox89.Controls.Add(this.label393);
            this.groupBox89.Controls.Add(this.label394);
            this.groupBox89.Controls.Add(this.label395);
            this.groupBox89.Controls.Add(this.label397);
            this.groupBox89.Controls.Add(this.label399);
            this.groupBox89.Controls.Add(this.label408);
            this.groupBox89.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox89.Location = new System.Drawing.Point(247, 326);
            this.groupBox89.Name = "groupBox89";
            this.groupBox89.Size = new System.Drawing.Size(781, 149);
            this.groupBox89.TabIndex = 73;
            this.groupBox89.TabStop = false;
            this.groupBox89.Text = "Point To Point Control";
            // 
            // btnStopPointS1
            // 
            this.btnStopPointS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnStopPointS1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopPointS1.ForeColor = System.Drawing.Color.White;
            this.btnStopPointS1.Location = new System.Drawing.Point(399, 103);
            this.btnStopPointS1.Name = "btnStopPointS1";
            this.btnStopPointS1.Size = new System.Drawing.Size(83, 38);
            this.btnStopPointS1.TabIndex = 71;
            this.btnStopPointS1.Text = "Stop";
            this.btnStopPointS1.UseVisualStyleBackColor = false;
            // 
            // btnMovePointS1
            // 
            this.btnMovePointS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMovePointS1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovePointS1.ForeColor = System.Drawing.Color.White;
            this.btnMovePointS1.Location = new System.Drawing.Point(203, 103);
            this.btnMovePointS1.Name = "btnMovePointS1";
            this.btnMovePointS1.Size = new System.Drawing.Size(83, 38);
            this.btnMovePointS1.TabIndex = 70;
            this.btnMovePointS1.Text = "Move";
            this.btnMovePointS1.UseVisualStyleBackColor = false;
            // 
            // textBox68
            // 
            this.textBox68.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox68.Location = new System.Drawing.Point(603, 28);
            this.textBox68.Name = "textBox68";
            this.textBox68.Size = new System.Drawing.Size(67, 26);
            this.textBox68.TabIndex = 61;
            // 
            // textBox79
            // 
            this.textBox79.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox79.Location = new System.Drawing.Point(336, 65);
            this.textBox79.Name = "textBox79";
            this.textBox79.Size = new System.Drawing.Size(67, 26);
            this.textBox79.TabIndex = 61;
            // 
            // textBox80
            // 
            this.textBox80.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox80.Location = new System.Drawing.Point(336, 28);
            this.textBox80.Name = "textBox80";
            this.textBox80.Size = new System.Drawing.Size(67, 26);
            this.textBox80.TabIndex = 61;
            // 
            // label387
            // 
            this.label387.AutoSize = true;
            this.label387.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label387.Location = new System.Drawing.Point(21, 80);
            this.label387.Name = "label387";
            this.label387.Size = new System.Drawing.Size(84, 14);
            this.label387.TabIndex = 37;
            this.label387.Text = "End Position";
            // 
            // label388
            // 
            this.label388.AutoSize = true;
            this.label388.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label388.Location = new System.Drawing.Point(14, 40);
            this.label388.Name = "label388";
            this.label388.Size = new System.Drawing.Size(93, 14);
            this.label388.TabIndex = 37;
            this.label388.Text = "Start Position";
            // 
            // textBox81
            // 
            this.textBox81.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox81.Location = new System.Drawing.Point(105, 71);
            this.textBox81.Name = "textBox81";
            this.textBox81.Size = new System.Drawing.Size(67, 26);
            this.textBox81.TabIndex = 59;
            // 
            // label389
            // 
            this.label389.AutoSize = true;
            this.label389.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label389.Location = new System.Drawing.Point(539, 40);
            this.label389.Name = "label389";
            this.label389.Size = new System.Drawing.Size(62, 14);
            this.label389.TabIndex = 60;
            this.label389.Text = "Iteration";
            // 
            // textBox82
            // 
            this.textBox82.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox82.Location = new System.Drawing.Point(105, 32);
            this.textBox82.Name = "textBox82";
            this.textBox82.Size = new System.Drawing.Size(67, 26);
            this.textBox82.TabIndex = 59;
            // 
            // label392
            // 
            this.label392.AutoSize = true;
            this.label392.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label392.Location = new System.Drawing.Point(297, 76);
            this.label392.Name = "label392";
            this.label392.Size = new System.Drawing.Size(35, 14);
            this.label392.TabIndex = 60;
            this.label392.Text = "Wait";
            // 
            // label393
            // 
            this.label393.AutoSize = true;
            this.label393.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label393.Location = new System.Drawing.Point(179, 80);
            this.label393.Name = "label393";
            this.label393.Size = new System.Drawing.Size(37, 14);
            this.label393.TabIndex = 66;
            this.label393.Text = "(mm)";
            // 
            // label394
            // 
            this.label394.AutoSize = true;
            this.label394.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label394.Location = new System.Drawing.Point(676, 40);
            this.label394.Name = "label394";
            this.label394.Size = new System.Drawing.Size(39, 14);
            this.label394.TabIndex = 67;
            this.label394.Text = "count";
            // 
            // label395
            // 
            this.label395.AutoSize = true;
            this.label395.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label395.Location = new System.Drawing.Point(287, 40);
            this.label395.Name = "label395";
            this.label395.Size = new System.Drawing.Size(45, 14);
            this.label395.TabIndex = 60;
            this.label395.Text = "Speed";
            // 
            // label397
            // 
            this.label397.AutoSize = true;
            this.label397.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label397.Location = new System.Drawing.Point(410, 76);
            this.label397.Name = "label397";
            this.label397.Size = new System.Drawing.Size(25, 14);
            this.label397.TabIndex = 67;
            this.label397.Text = "sec";
            // 
            // label399
            // 
            this.label399.AutoSize = true;
            this.label399.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label399.Location = new System.Drawing.Point(179, 40);
            this.label399.Name = "label399";
            this.label399.Size = new System.Drawing.Size(37, 14);
            this.label399.TabIndex = 66;
            this.label399.Text = "(mm)";
            // 
            // label408
            // 
            this.label408.AutoSize = true;
            this.label408.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label408.Location = new System.Drawing.Point(410, 40);
            this.label408.Name = "label408";
            this.label408.Size = new System.Drawing.Size(47, 14);
            this.label408.TabIndex = 67;
            this.label408.Text = "(mm/s)";
            // 
            // groupBox90
            // 
            this.groupBox90.BackColor = System.Drawing.Color.White;
            this.groupBox90.Controls.Add(this.comboBox3);
            this.groupBox90.Controls.Add(this.label409);
            this.groupBox90.Controls.Add(this.textBox83);
            this.groupBox90.Controls.Add(this.label410);
            this.groupBox90.Controls.Add(this.label411);
            this.groupBox90.Controls.Add(this.btnJogDecS1);
            this.groupBox90.Controls.Add(this.btnJogAddS1);
            this.groupBox90.Controls.Add(this.label423);
            this.groupBox90.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox90.Location = new System.Drawing.Point(795, 149);
            this.groupBox90.Name = "groupBox90";
            this.groupBox90.Size = new System.Drawing.Size(234, 168);
            this.groupBox90.TabIndex = 72;
            this.groupBox90.TabStop = false;
            this.groupBox90.Text = "Jog Control";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox3.Location = new System.Drawing.Point(105, 64);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(67, 26);
            this.comboBox3.TabIndex = 78;
            // 
            // label409
            // 
            this.label409.AutoSize = true;
            this.label409.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label409.Location = new System.Drawing.Point(176, 41);
            this.label409.Name = "label409";
            this.label409.Size = new System.Drawing.Size(37, 14);
            this.label409.TabIndex = 77;
            this.label409.Text = "(mm)";
            // 
            // textBox83
            // 
            this.textBox83.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox83.Location = new System.Drawing.Point(105, 32);
            this.textBox83.Name = "textBox83";
            this.textBox83.Size = new System.Drawing.Size(67, 26);
            this.textBox83.TabIndex = 76;
            // 
            // label410
            // 
            this.label410.AutoSize = true;
            this.label410.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label410.Location = new System.Drawing.Point(20, 40);
            this.label410.Name = "label410";
            this.label410.Size = new System.Drawing.Size(83, 14);
            this.label410.TabIndex = 75;
            this.label410.Text = "Jog Position";
            // 
            // label411
            // 
            this.label411.AutoSize = true;
            this.label411.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label411.Location = new System.Drawing.Point(172, 71);
            this.label411.Name = "label411";
            this.label411.Size = new System.Drawing.Size(47, 14);
            this.label411.TabIndex = 73;
            this.label411.Text = "(mm/s)";
            // 
            // btnJogDecS1
            // 
            this.btnJogDecS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogDecS1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogDecS1.ForeColor = System.Drawing.Color.White;
            this.btnJogDecS1.Location = new System.Drawing.Point(123, 107);
            this.btnJogDecS1.Name = "btnJogDecS1";
            this.btnJogDecS1.Size = new System.Drawing.Size(83, 38);
            this.btnJogDecS1.TabIndex = 74;
            this.btnJogDecS1.Text = "Jog -";
            this.btnJogDecS1.UseVisualStyleBackColor = false;
            // 
            // btnJogAddS1
            // 
            this.btnJogAddS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogAddS1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogAddS1.ForeColor = System.Drawing.Color.White;
            this.btnJogAddS1.Location = new System.Drawing.Point(24, 107);
            this.btnJogAddS1.Name = "btnJogAddS1";
            this.btnJogAddS1.Size = new System.Drawing.Size(83, 38);
            this.btnJogAddS1.TabIndex = 73;
            this.btnJogAddS1.Text = "Jog +";
            this.btnJogAddS1.UseVisualStyleBackColor = false;
            // 
            // label423
            // 
            this.label423.AutoSize = true;
            this.label423.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label423.Location = new System.Drawing.Point(20, 72);
            this.label423.Name = "label423";
            this.label423.Size = new System.Drawing.Size(81, 14);
            this.label423.TabIndex = 37;
            this.label423.Text = "Jog Velocity";
            // 
            // groupBox91
            // 
            this.groupBox91.BackColor = System.Drawing.Color.White;
            this.groupBox91.Controls.Add(this.btnHomeStopS1);
            this.groupBox91.Controls.Add(this.label424);
            this.groupBox91.Controls.Add(this.btnHomeS1);
            this.groupBox91.Controls.Add(this.textBox84);
            this.groupBox91.Controls.Add(this.label425);
            this.groupBox91.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox91.Location = new System.Drawing.Point(507, 153);
            this.groupBox91.Name = "groupBox91";
            this.groupBox91.Size = new System.Drawing.Size(234, 168);
            this.groupBox91.TabIndex = 71;
            this.groupBox91.TabStop = false;
            this.groupBox91.Text = "Homing Control";
            // 
            // btnHomeStopS1
            // 
            this.btnHomeStopS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeStopS1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeStopS1.ForeColor = System.Drawing.Color.White;
            this.btnHomeStopS1.Location = new System.Drawing.Point(141, 107);
            this.btnHomeStopS1.Name = "btnHomeStopS1";
            this.btnHomeStopS1.Size = new System.Drawing.Size(83, 38);
            this.btnHomeStopS1.TabIndex = 73;
            this.btnHomeStopS1.Text = "Stop";
            this.btnHomeStopS1.UseVisualStyleBackColor = false;
            // 
            // label424
            // 
            this.label424.AutoSize = true;
            this.label424.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label424.Location = new System.Drawing.Point(179, 55);
            this.label424.Name = "label424";
            this.label424.Size = new System.Drawing.Size(47, 14);
            this.label424.TabIndex = 72;
            this.label424.Text = "(mm/s)";
            // 
            // btnHomeS1
            // 
            this.btnHomeS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeS1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeS1.ForeColor = System.Drawing.Color.White;
            this.btnHomeS1.Location = new System.Drawing.Point(19, 107);
            this.btnHomeS1.Name = "btnHomeS1";
            this.btnHomeS1.Size = new System.Drawing.Size(83, 38);
            this.btnHomeS1.TabIndex = 72;
            this.btnHomeS1.Text = "Home";
            this.btnHomeS1.UseVisualStyleBackColor = false;
            // 
            // textBox84
            // 
            this.textBox84.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox84.Location = new System.Drawing.Point(108, 47);
            this.textBox84.Name = "textBox84";
            this.textBox84.Size = new System.Drawing.Size(67, 26);
            this.textBox84.TabIndex = 59;
            // 
            // label425
            // 
            this.label425.AutoSize = true;
            this.label425.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label425.Location = new System.Drawing.Point(9, 55);
            this.label425.Name = "label425";
            this.label425.Size = new System.Drawing.Size(94, 14);
            this.label425.TabIndex = 37;
            this.label425.Text = "Home Velocity";
            // 
            // groupBox92
            // 
            this.groupBox92.BackColor = System.Drawing.Color.White;
            this.groupBox92.Controls.Add(this.btnMotionStopS1);
            this.groupBox92.Controls.Add(this.btnMotionMoveS1);
            this.groupBox92.Controls.Add(this.label426);
            this.groupBox92.Controls.Add(this.label427);
            this.groupBox92.Controls.Add(this.txtShuttle1_TargetSpeed);
            this.groupBox92.Controls.Add(this.label428);
            this.groupBox92.Controls.Add(this.txtServoS1_Targetposition);
            this.groupBox92.Controls.Add(this.label429);
            this.groupBox92.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox92.Location = new System.Drawing.Point(247, 149);
            this.groupBox92.Name = "groupBox92";
            this.groupBox92.Size = new System.Drawing.Size(205, 168);
            this.groupBox92.TabIndex = 56;
            this.groupBox92.TabStop = false;
            this.groupBox92.Text = "Motion Control";
            // 
            // btnMotionStopS1
            // 
            this.btnMotionStopS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMotionStopS1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMotionStopS1.ForeColor = System.Drawing.Color.White;
            this.btnMotionStopS1.Location = new System.Drawing.Point(111, 111);
            this.btnMotionStopS1.Name = "btnMotionStopS1";
            this.btnMotionStopS1.Size = new System.Drawing.Size(83, 38);
            this.btnMotionStopS1.TabIndex = 73;
            this.btnMotionStopS1.Text = "Stop";
            this.btnMotionStopS1.UseVisualStyleBackColor = false;
            // 
            // btnMotionMoveS1
            // 
            this.btnMotionMoveS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMotionMoveS1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMotionMoveS1.ForeColor = System.Drawing.Color.White;
            this.btnMotionMoveS1.Location = new System.Drawing.Point(15, 111);
            this.btnMotionMoveS1.Name = "btnMotionMoveS1";
            this.btnMotionMoveS1.Size = new System.Drawing.Size(83, 38);
            this.btnMotionMoveS1.TabIndex = 70;
            this.btnMotionMoveS1.Text = "Move";
            this.btnMotionMoveS1.UseVisualStyleBackColor = false;
            // 
            // label426
            // 
            this.label426.AutoSize = true;
            this.label426.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label426.Location = new System.Drawing.Point(148, 79);
            this.label426.Name = "label426";
            this.label426.Size = new System.Drawing.Size(47, 14);
            this.label426.TabIndex = 67;
            this.label426.Text = "(mm/s)";
            // 
            // label427
            // 
            this.label427.AutoSize = true;
            this.label427.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label427.Location = new System.Drawing.Point(148, 37);
            this.label427.Name = "label427";
            this.label427.Size = new System.Drawing.Size(37, 14);
            this.label427.TabIndex = 66;
            this.label427.Text = "(mm)";
            // 
            // txtShuttle1_TargetSpeed
            // 
            this.txtShuttle1_TargetSpeed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShuttle1_TargetSpeed.Location = new System.Drawing.Point(75, 66);
            this.txtShuttle1_TargetSpeed.Name = "txtShuttle1_TargetSpeed";
            this.txtShuttle1_TargetSpeed.Size = new System.Drawing.Size(67, 26);
            this.txtShuttle1_TargetSpeed.TabIndex = 61;
            // 
            // label428
            // 
            this.label428.AutoSize = true;
            this.label428.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label428.Location = new System.Drawing.Point(14, 73);
            this.label428.Name = "label428";
            this.label428.Size = new System.Drawing.Size(45, 14);
            this.label428.TabIndex = 60;
            this.label428.Text = "Speed";
            // 
            // txtServoS1_Targetposition
            // 
            this.txtServoS1_Targetposition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServoS1_Targetposition.Location = new System.Drawing.Point(75, 29);
            this.txtServoS1_Targetposition.Name = "txtServoS1_Targetposition";
            this.txtServoS1_Targetposition.Size = new System.Drawing.Size(67, 26);
            this.txtServoS1_Targetposition.TabIndex = 59;
            // 
            // label429
            // 
            this.label429.AutoSize = true;
            this.label429.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label429.Location = new System.Drawing.Point(14, 36);
            this.label429.Name = "label429";
            this.label429.Size = new System.Drawing.Size(57, 14);
            this.label429.TabIndex = 37;
            this.label429.Text = "Position";
            // 
            // groupBox102
            // 
            this.groupBox102.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox102.Controls.Add(this.lblSh1servoEnable);
            this.groupBox102.Controls.Add(this.lblSh1servo_PositiveLimit);
            this.groupBox102.Controls.Add(this.label431);
            this.groupBox102.Controls.Add(this.lblSh1servo_NegativeLimit);
            this.groupBox102.Controls.Add(this.label433);
            this.groupBox102.Controls.Add(this.lblSh1servoDisable);
            this.groupBox102.Controls.Add(this.label435);
            this.groupBox102.Controls.Add(this.lblSh1servo_Error);
            this.groupBox102.Controls.Add(this.label437);
            this.groupBox102.Controls.Add(this.lblSh1servo_Home);
            this.groupBox102.Controls.Add(this.label439);
            this.groupBox102.Controls.Add(this.label440);
            this.groupBox102.Controls.Add(this.label442);
            this.groupBox102.Controls.Add(this.label443);
            this.groupBox102.Controls.Add(this.label444);
            this.groupBox102.Controls.Add(this.label445);
            this.groupBox102.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox102.Location = new System.Drawing.Point(15, 14);
            this.groupBox102.Name = "groupBox102";
            this.groupBox102.Size = new System.Drawing.Size(687, 128);
            this.groupBox102.TabIndex = 37;
            this.groupBox102.TabStop = false;
            this.groupBox102.Text = "Device Status";
            // 
            // lblSh1servoEnable
            // 
            this.lblSh1servoEnable.BackColor = System.Drawing.Color.Maroon;
            this.lblSh1servoEnable.Location = new System.Drawing.Point(111, 29);
            this.lblSh1servoEnable.Name = "lblSh1servoEnable";
            this.lblSh1servoEnable.Size = new System.Drawing.Size(27, 26);
            this.lblSh1servoEnable.TabIndex = 66;
            // 
            // lblSh1servo_PositiveLimit
            // 
            this.lblSh1servo_PositiveLimit.BackColor = System.Drawing.Color.Maroon;
            this.lblSh1servo_PositiveLimit.Location = new System.Drawing.Point(639, 87);
            this.lblSh1servo_PositiveLimit.Name = "lblSh1servo_PositiveLimit";
            this.lblSh1servo_PositiveLimit.Size = new System.Drawing.Size(27, 26);
            this.lblSh1servo_PositiveLimit.TabIndex = 65;
            // 
            // label431
            // 
            this.label431.AutoSize = true;
            this.label431.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label431.Location = new System.Drawing.Point(545, 94);
            this.label431.Name = "label431";
            this.label431.Size = new System.Drawing.Size(89, 14);
            this.label431.TabIndex = 64;
            this.label431.Text = "Positive Limit";
            // 
            // lblSh1servo_NegativeLimit
            // 
            this.lblSh1servo_NegativeLimit.BackColor = System.Drawing.Color.Maroon;
            this.lblSh1servo_NegativeLimit.Location = new System.Drawing.Point(639, 33);
            this.lblSh1servo_NegativeLimit.Name = "lblSh1servo_NegativeLimit";
            this.lblSh1servo_NegativeLimit.Size = new System.Drawing.Size(27, 26);
            this.lblSh1servo_NegativeLimit.TabIndex = 63;
            // 
            // label433
            // 
            this.label433.AutoSize = true;
            this.label433.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label433.Location = new System.Drawing.Point(541, 41);
            this.label433.Name = "label433";
            this.label433.Size = new System.Drawing.Size(94, 14);
            this.label433.TabIndex = 62;
            this.label433.Text = "Negative Limit";
            // 
            // lblSh1servoDisable
            // 
            this.lblSh1servoDisable.BackColor = System.Drawing.Color.Maroon;
            this.lblSh1servoDisable.Location = new System.Drawing.Point(111, 84);
            this.lblSh1servoDisable.Name = "lblSh1servoDisable";
            this.lblSh1servoDisable.Size = new System.Drawing.Size(27, 26);
            this.lblSh1servoDisable.TabIndex = 61;
            // 
            // label435
            // 
            this.label435.AutoSize = true;
            this.label435.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label435.Location = new System.Drawing.Point(22, 93);
            this.label435.Name = "label435";
            this.label435.Size = new System.Drawing.Size(89, 14);
            this.label435.TabIndex = 60;
            this.label435.Text = "Servo Disable";
            // 
            // lblSh1servo_Error
            // 
            this.lblSh1servo_Error.BackColor = System.Drawing.Color.Maroon;
            this.lblSh1servo_Error.Location = new System.Drawing.Point(465, 84);
            this.lblSh1servo_Error.Name = "lblSh1servo_Error";
            this.lblSh1servo_Error.Size = new System.Drawing.Size(27, 26);
            this.lblSh1servo_Error.TabIndex = 58;
            // 
            // label437
            // 
            this.label437.AutoSize = true;
            this.label437.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label437.Location = new System.Drawing.Point(371, 93);
            this.label437.Name = "label437";
            this.label437.Size = new System.Drawing.Size(93, 14);
            this.label437.TabIndex = 57;
            this.label437.Text = "Servo In Error";
            // 
            // lblSh1servo_Home
            // 
            this.lblSh1servo_Home.BackColor = System.Drawing.Color.Maroon;
            this.lblSh1servo_Home.Location = new System.Drawing.Point(465, 33);
            this.lblSh1servo_Home.Name = "lblSh1servo_Home";
            this.lblSh1servo_Home.Size = new System.Drawing.Size(27, 26);
            this.lblSh1servo_Home.TabIndex = 48;
            // 
            // label439
            // 
            this.label439.BackColor = System.Drawing.Color.Maroon;
            this.label439.Location = new System.Drawing.Point(291, 84);
            this.label439.Name = "label439";
            this.label439.Size = new System.Drawing.Size(27, 26);
            this.label439.TabIndex = 47;
            // 
            // label440
            // 
            this.label440.BackColor = System.Drawing.Color.Maroon;
            this.label440.Location = new System.Drawing.Point(291, 29);
            this.label440.Name = "label440";
            this.label440.Size = new System.Drawing.Size(27, 26);
            this.label440.TabIndex = 46;
            // 
            // label442
            // 
            this.label442.AutoSize = true;
            this.label442.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label442.Location = new System.Drawing.Point(191, 93);
            this.label442.Name = "label442";
            this.label442.Size = new System.Drawing.Size(98, 14);
            this.label442.TabIndex = 43;
            this.label442.Text = "Servo Running";
            // 
            // label443
            // 
            this.label443.AutoSize = true;
            this.label443.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label443.Location = new System.Drawing.Point(383, 41);
            this.label443.Name = "label443";
            this.label443.Size = new System.Drawing.Size(81, 14);
            this.label443.TabIndex = 41;
            this.label443.Text = "Servo Home";
            // 
            // label444
            // 
            this.label444.AutoSize = true;
            this.label444.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label444.Location = new System.Drawing.Point(206, 38);
            this.label444.Name = "label444";
            this.label444.Size = new System.Drawing.Size(84, 14);
            this.label444.TabIndex = 39;
            this.label444.Text = "Servo Ready";
            // 
            // label445
            // 
            this.label445.AutoSize = true;
            this.label445.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label445.Location = new System.Drawing.Point(22, 38);
            this.label445.Name = "label445";
            this.label445.Size = new System.Drawing.Size(86, 14);
            this.label445.TabIndex = 37;
            this.label445.Text = "Servo Enable";
            // 
            // Shuttle2
            // 
            this.Shuttle2.BackColor = System.Drawing.Color.LightGray;
            this.Shuttle2.Controls.Add(this.groupBox103);
            this.Shuttle2.Location = new System.Drawing.Point(4, 27);
            this.Shuttle2.Name = "Shuttle2";
            this.Shuttle2.Padding = new System.Windows.Forms.Padding(3);
            this.Shuttle2.Size = new System.Drawing.Size(1561, 603);
            this.Shuttle2.TabIndex = 1;
            this.Shuttle2.Text = "Shuttle2";
            // 
            // groupBox103
            // 
            this.groupBox103.BackColor = System.Drawing.Color.White;
            this.groupBox103.Controls.Add(this.groupBox112);
            this.groupBox103.Controls.Add(this.groupBox106);
            this.groupBox103.Controls.Add(this.groupBox107);
            this.groupBox103.Controls.Add(this.groupBox108);
            this.groupBox103.Controls.Add(this.groupBox109);
            this.groupBox103.Controls.Add(this.groupBox110);
            this.groupBox103.Controls.Add(this.groupBox111);
            this.groupBox103.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox103.Location = new System.Drawing.Point(239, 47);
            this.groupBox103.Name = "groupBox103";
            this.groupBox103.Size = new System.Drawing.Size(1053, 485);
            this.groupBox103.TabIndex = 82;
            this.groupBox103.TabStop = false;
            // 
            // groupBox112
            // 
            this.groupBox112.Controls.Add(this.btnShuttle2Enable);
            this.groupBox112.Controls.Add(this.btnShuttle2ClearErr);
            this.groupBox112.Controls.Add(this.btnShuttle2Disable);
            this.groupBox112.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox112.Location = new System.Drawing.Point(15, 156);
            this.groupBox112.Name = "groupBox112";
            this.groupBox112.Size = new System.Drawing.Size(177, 168);
            this.groupBox112.TabIndex = 76;
            this.groupBox112.TabStop = false;
            this.groupBox112.Text = "Device Control";
            // 
            // btnShuttle2Enable
            // 
            this.btnShuttle2Enable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnShuttle2Enable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShuttle2Enable.ForeColor = System.Drawing.Color.White;
            this.btnShuttle2Enable.Location = new System.Drawing.Point(11, 27);
            this.btnShuttle2Enable.Name = "btnShuttle2Enable";
            this.btnShuttle2Enable.Size = new System.Drawing.Size(147, 38);
            this.btnShuttle2Enable.TabIndex = 72;
            this.btnShuttle2Enable.Text = "Servo Enable";
            this.btnShuttle2Enable.UseVisualStyleBackColor = false;
            // 
            // btnShuttle2ClearErr
            // 
            this.btnShuttle2ClearErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnShuttle2ClearErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShuttle2ClearErr.ForeColor = System.Drawing.Color.White;
            this.btnShuttle2ClearErr.Location = new System.Drawing.Point(11, 114);
            this.btnShuttle2ClearErr.Name = "btnShuttle2ClearErr";
            this.btnShuttle2ClearErr.Size = new System.Drawing.Size(147, 38);
            this.btnShuttle2ClearErr.TabIndex = 71;
            this.btnShuttle2ClearErr.Text = "Servo Clear Error";
            this.btnShuttle2ClearErr.UseVisualStyleBackColor = false;
            // 
            // btnShuttle2Disable
            // 
            this.btnShuttle2Disable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnShuttle2Disable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShuttle2Disable.ForeColor = System.Drawing.Color.White;
            this.btnShuttle2Disable.Location = new System.Drawing.Point(11, 70);
            this.btnShuttle2Disable.Name = "btnShuttle2Disable";
            this.btnShuttle2Disable.Size = new System.Drawing.Size(147, 38);
            this.btnShuttle2Disable.TabIndex = 71;
            this.btnShuttle2Disable.Text = "Servo Disable";
            this.btnShuttle2Disable.UseVisualStyleBackColor = false;
            // 
            // groupBox106
            // 
            this.groupBox106.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox106.Controls.Add(this.label446);
            this.groupBox106.Controls.Add(this.lbl_Sh2_ActualPosition);
            this.groupBox106.Controls.Add(this.label448);
            this.groupBox106.Controls.Add(this.label449);
            this.groupBox106.Controls.Add(this.label450);
            this.groupBox106.Controls.Add(this.lbl_Shuttle2_TargetPosition);
            this.groupBox106.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox106.Location = new System.Drawing.Point(732, 14);
            this.groupBox106.Name = "groupBox106";
            this.groupBox106.Size = new System.Drawing.Size(297, 128);
            this.groupBox106.TabIndex = 74;
            this.groupBox106.TabStop = false;
            this.groupBox106.Text = "Live Values";
            // 
            // label446
            // 
            this.label446.AutoSize = true;
            this.label446.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label446.Location = new System.Drawing.Point(232, 81);
            this.label446.Name = "label446";
            this.label446.Size = new System.Drawing.Size(47, 14);
            this.label446.TabIndex = 73;
            this.label446.Text = "(mm/s)";
            // 
            // lbl_Sh2_ActualPosition
            // 
            this.lbl_Sh2_ActualPosition.AutoSize = true;
            this.lbl_Sh2_ActualPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Sh2_ActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Sh2_ActualPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sh2_ActualPosition.Location = new System.Drawing.Point(175, 45);
            this.lbl_Sh2_ActualPosition.Name = "lbl_Sh2_ActualPosition";
            this.lbl_Sh2_ActualPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_Sh2_ActualPosition.TabIndex = 53;
            this.lbl_Sh2_ActualPosition.Text = "0";
            this.lbl_Sh2_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label448
            // 
            this.label448.AutoSize = true;
            this.label448.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label448.Location = new System.Drawing.Point(232, 45);
            this.label448.Name = "label448";
            this.label448.Size = new System.Drawing.Size(37, 14);
            this.label448.TabIndex = 75;
            this.label448.Text = "(mm)";
            // 
            // label449
            // 
            this.label449.AutoSize = true;
            this.label449.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label449.Location = new System.Drawing.Point(10, 45);
            this.label449.Name = "label449";
            this.label449.Size = new System.Drawing.Size(139, 14);
            this.label449.TabIndex = 52;
            this.label449.Text = "Servo Actual Position";
            // 
            // label450
            // 
            this.label450.AutoSize = true;
            this.label450.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label450.Location = new System.Drawing.Point(10, 81);
            this.label450.Name = "label450";
            this.label450.Size = new System.Drawing.Size(137, 14);
            this.label450.TabIndex = 54;
            this.label450.Text = "Servo Actual Velocity";
            // 
            // lbl_Shuttle2_TargetPosition
            // 
            this.lbl_Shuttle2_TargetPosition.AutoSize = true;
            this.lbl_Shuttle2_TargetPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Shuttle2_TargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Shuttle2_TargetPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Shuttle2_TargetPosition.Location = new System.Drawing.Point(175, 81);
            this.lbl_Shuttle2_TargetPosition.Name = "lbl_Shuttle2_TargetPosition";
            this.lbl_Shuttle2_TargetPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_Shuttle2_TargetPosition.TabIndex = 55;
            this.lbl_Shuttle2_TargetPosition.Text = "0";
            this.lbl_Shuttle2_TargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox107
            // 
            this.groupBox107.Controls.Add(this.btnStopPointS2);
            this.groupBox107.Controls.Add(this.btnMovePointS2);
            this.groupBox107.Controls.Add(this.textBox87);
            this.groupBox107.Controls.Add(this.textBox88);
            this.groupBox107.Controls.Add(this.textBox89);
            this.groupBox107.Controls.Add(this.label452);
            this.groupBox107.Controls.Add(this.label453);
            this.groupBox107.Controls.Add(this.textBox90);
            this.groupBox107.Controls.Add(this.label454);
            this.groupBox107.Controls.Add(this.textBox91);
            this.groupBox107.Controls.Add(this.label455);
            this.groupBox107.Controls.Add(this.label456);
            this.groupBox107.Controls.Add(this.label457);
            this.groupBox107.Controls.Add(this.label458);
            this.groupBox107.Controls.Add(this.label459);
            this.groupBox107.Controls.Add(this.label460);
            this.groupBox107.Controls.Add(this.label461);
            this.groupBox107.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox107.Location = new System.Drawing.Point(247, 326);
            this.groupBox107.Name = "groupBox107";
            this.groupBox107.Size = new System.Drawing.Size(781, 149);
            this.groupBox107.TabIndex = 73;
            this.groupBox107.TabStop = false;
            this.groupBox107.Text = "Point To Point Control";
            // 
            // btnStopPointS2
            // 
            this.btnStopPointS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnStopPointS2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopPointS2.ForeColor = System.Drawing.Color.White;
            this.btnStopPointS2.Location = new System.Drawing.Point(399, 103);
            this.btnStopPointS2.Name = "btnStopPointS2";
            this.btnStopPointS2.Size = new System.Drawing.Size(83, 38);
            this.btnStopPointS2.TabIndex = 71;
            this.btnStopPointS2.Text = "Stop";
            this.btnStopPointS2.UseVisualStyleBackColor = false;
            // 
            // btnMovePointS2
            // 
            this.btnMovePointS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMovePointS2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovePointS2.ForeColor = System.Drawing.Color.White;
            this.btnMovePointS2.Location = new System.Drawing.Point(203, 103);
            this.btnMovePointS2.Name = "btnMovePointS2";
            this.btnMovePointS2.Size = new System.Drawing.Size(83, 38);
            this.btnMovePointS2.TabIndex = 70;
            this.btnMovePointS2.Text = "Move";
            this.btnMovePointS2.UseVisualStyleBackColor = false;
            // 
            // textBox87
            // 
            this.textBox87.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox87.Location = new System.Drawing.Point(603, 28);
            this.textBox87.Name = "textBox87";
            this.textBox87.Size = new System.Drawing.Size(67, 26);
            this.textBox87.TabIndex = 61;
            // 
            // textBox88
            // 
            this.textBox88.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox88.Location = new System.Drawing.Point(336, 65);
            this.textBox88.Name = "textBox88";
            this.textBox88.Size = new System.Drawing.Size(67, 26);
            this.textBox88.TabIndex = 61;
            // 
            // textBox89
            // 
            this.textBox89.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox89.Location = new System.Drawing.Point(336, 28);
            this.textBox89.Name = "textBox89";
            this.textBox89.Size = new System.Drawing.Size(67, 26);
            this.textBox89.TabIndex = 61;
            // 
            // label452
            // 
            this.label452.AutoSize = true;
            this.label452.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label452.Location = new System.Drawing.Point(21, 80);
            this.label452.Name = "label452";
            this.label452.Size = new System.Drawing.Size(84, 14);
            this.label452.TabIndex = 37;
            this.label452.Text = "End Position";
            // 
            // label453
            // 
            this.label453.AutoSize = true;
            this.label453.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label453.Location = new System.Drawing.Point(14, 40);
            this.label453.Name = "label453";
            this.label453.Size = new System.Drawing.Size(93, 14);
            this.label453.TabIndex = 37;
            this.label453.Text = "Start Position";
            // 
            // textBox90
            // 
            this.textBox90.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox90.Location = new System.Drawing.Point(105, 71);
            this.textBox90.Name = "textBox90";
            this.textBox90.Size = new System.Drawing.Size(67, 26);
            this.textBox90.TabIndex = 59;
            // 
            // label454
            // 
            this.label454.AutoSize = true;
            this.label454.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label454.Location = new System.Drawing.Point(539, 40);
            this.label454.Name = "label454";
            this.label454.Size = new System.Drawing.Size(62, 14);
            this.label454.TabIndex = 60;
            this.label454.Text = "Iteration";
            // 
            // textBox91
            // 
            this.textBox91.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox91.Location = new System.Drawing.Point(105, 32);
            this.textBox91.Name = "textBox91";
            this.textBox91.Size = new System.Drawing.Size(67, 26);
            this.textBox91.TabIndex = 59;
            // 
            // label455
            // 
            this.label455.AutoSize = true;
            this.label455.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label455.Location = new System.Drawing.Point(297, 76);
            this.label455.Name = "label455";
            this.label455.Size = new System.Drawing.Size(35, 14);
            this.label455.TabIndex = 60;
            this.label455.Text = "Wait";
            // 
            // label456
            // 
            this.label456.AutoSize = true;
            this.label456.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label456.Location = new System.Drawing.Point(179, 80);
            this.label456.Name = "label456";
            this.label456.Size = new System.Drawing.Size(37, 14);
            this.label456.TabIndex = 66;
            this.label456.Text = "(mm)";
            // 
            // label457
            // 
            this.label457.AutoSize = true;
            this.label457.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label457.Location = new System.Drawing.Point(676, 40);
            this.label457.Name = "label457";
            this.label457.Size = new System.Drawing.Size(39, 14);
            this.label457.TabIndex = 67;
            this.label457.Text = "count";
            // 
            // label458
            // 
            this.label458.AutoSize = true;
            this.label458.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label458.Location = new System.Drawing.Point(287, 40);
            this.label458.Name = "label458";
            this.label458.Size = new System.Drawing.Size(45, 14);
            this.label458.TabIndex = 60;
            this.label458.Text = "Speed";
            // 
            // label459
            // 
            this.label459.AutoSize = true;
            this.label459.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label459.Location = new System.Drawing.Point(410, 76);
            this.label459.Name = "label459";
            this.label459.Size = new System.Drawing.Size(25, 14);
            this.label459.TabIndex = 67;
            this.label459.Text = "sec";
            // 
            // label460
            // 
            this.label460.AutoSize = true;
            this.label460.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label460.Location = new System.Drawing.Point(179, 40);
            this.label460.Name = "label460";
            this.label460.Size = new System.Drawing.Size(37, 14);
            this.label460.TabIndex = 66;
            this.label460.Text = "(mm)";
            // 
            // label461
            // 
            this.label461.AutoSize = true;
            this.label461.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label461.Location = new System.Drawing.Point(410, 40);
            this.label461.Name = "label461";
            this.label461.Size = new System.Drawing.Size(47, 14);
            this.label461.TabIndex = 67;
            this.label461.Text = "(mm/s)";
            // 
            // groupBox108
            // 
            this.groupBox108.BackColor = System.Drawing.Color.White;
            this.groupBox108.Controls.Add(this.comboBox8);
            this.groupBox108.Controls.Add(this.label462);
            this.groupBox108.Controls.Add(this.textBox92);
            this.groupBox108.Controls.Add(this.label463);
            this.groupBox108.Controls.Add(this.label464);
            this.groupBox108.Controls.Add(this.btnJogDecS2);
            this.groupBox108.Controls.Add(this.btnJogAddS2);
            this.groupBox108.Controls.Add(this.label465);
            this.groupBox108.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox108.Location = new System.Drawing.Point(795, 149);
            this.groupBox108.Name = "groupBox108";
            this.groupBox108.Size = new System.Drawing.Size(234, 168);
            this.groupBox108.TabIndex = 72;
            this.groupBox108.TabStop = false;
            this.groupBox108.Text = "Jog Control";
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox8.Location = new System.Drawing.Point(105, 64);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(67, 26);
            this.comboBox8.TabIndex = 78;
            // 
            // label462
            // 
            this.label462.AutoSize = true;
            this.label462.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label462.Location = new System.Drawing.Point(176, 41);
            this.label462.Name = "label462";
            this.label462.Size = new System.Drawing.Size(37, 14);
            this.label462.TabIndex = 77;
            this.label462.Text = "(mm)";
            // 
            // textBox92
            // 
            this.textBox92.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox92.Location = new System.Drawing.Point(105, 32);
            this.textBox92.Name = "textBox92";
            this.textBox92.Size = new System.Drawing.Size(67, 26);
            this.textBox92.TabIndex = 76;
            // 
            // label463
            // 
            this.label463.AutoSize = true;
            this.label463.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label463.Location = new System.Drawing.Point(20, 40);
            this.label463.Name = "label463";
            this.label463.Size = new System.Drawing.Size(83, 14);
            this.label463.TabIndex = 75;
            this.label463.Text = "Jog Position";
            // 
            // label464
            // 
            this.label464.AutoSize = true;
            this.label464.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label464.Location = new System.Drawing.Point(172, 71);
            this.label464.Name = "label464";
            this.label464.Size = new System.Drawing.Size(47, 14);
            this.label464.TabIndex = 73;
            this.label464.Text = "(mm/s)";
            // 
            // btnJogDecS2
            // 
            this.btnJogDecS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogDecS2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogDecS2.ForeColor = System.Drawing.Color.White;
            this.btnJogDecS2.Location = new System.Drawing.Point(123, 107);
            this.btnJogDecS2.Name = "btnJogDecS2";
            this.btnJogDecS2.Size = new System.Drawing.Size(83, 38);
            this.btnJogDecS2.TabIndex = 74;
            this.btnJogDecS2.Text = "Jog -";
            this.btnJogDecS2.UseVisualStyleBackColor = false;
            // 
            // btnJogAddS2
            // 
            this.btnJogAddS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogAddS2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogAddS2.ForeColor = System.Drawing.Color.White;
            this.btnJogAddS2.Location = new System.Drawing.Point(24, 107);
            this.btnJogAddS2.Name = "btnJogAddS2";
            this.btnJogAddS2.Size = new System.Drawing.Size(83, 38);
            this.btnJogAddS2.TabIndex = 73;
            this.btnJogAddS2.Text = "Jog +";
            this.btnJogAddS2.UseVisualStyleBackColor = false;
            // 
            // label465
            // 
            this.label465.AutoSize = true;
            this.label465.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label465.Location = new System.Drawing.Point(20, 72);
            this.label465.Name = "label465";
            this.label465.Size = new System.Drawing.Size(81, 14);
            this.label465.TabIndex = 37;
            this.label465.Text = "Jog Velocity";
            // 
            // groupBox109
            // 
            this.groupBox109.BackColor = System.Drawing.Color.White;
            this.groupBox109.Controls.Add(this.btnHomeStopS2);
            this.groupBox109.Controls.Add(this.label466);
            this.groupBox109.Controls.Add(this.btnHomeS2);
            this.groupBox109.Controls.Add(this.textBox93);
            this.groupBox109.Controls.Add(this.label467);
            this.groupBox109.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox109.Location = new System.Drawing.Point(507, 153);
            this.groupBox109.Name = "groupBox109";
            this.groupBox109.Size = new System.Drawing.Size(234, 168);
            this.groupBox109.TabIndex = 71;
            this.groupBox109.TabStop = false;
            this.groupBox109.Text = "Homing Control";
            // 
            // btnHomeStopS2
            // 
            this.btnHomeStopS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeStopS2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeStopS2.ForeColor = System.Drawing.Color.White;
            this.btnHomeStopS2.Location = new System.Drawing.Point(141, 107);
            this.btnHomeStopS2.Name = "btnHomeStopS2";
            this.btnHomeStopS2.Size = new System.Drawing.Size(83, 38);
            this.btnHomeStopS2.TabIndex = 73;
            this.btnHomeStopS2.Text = "Stop";
            this.btnHomeStopS2.UseVisualStyleBackColor = false;
            // 
            // label466
            // 
            this.label466.AutoSize = true;
            this.label466.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label466.Location = new System.Drawing.Point(179, 55);
            this.label466.Name = "label466";
            this.label466.Size = new System.Drawing.Size(47, 14);
            this.label466.TabIndex = 72;
            this.label466.Text = "(mm/s)";
            // 
            // btnHomeS2
            // 
            this.btnHomeS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeS2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeS2.ForeColor = System.Drawing.Color.White;
            this.btnHomeS2.Location = new System.Drawing.Point(19, 107);
            this.btnHomeS2.Name = "btnHomeS2";
            this.btnHomeS2.Size = new System.Drawing.Size(83, 38);
            this.btnHomeS2.TabIndex = 72;
            this.btnHomeS2.Text = "Home";
            this.btnHomeS2.UseVisualStyleBackColor = false;
            // 
            // textBox93
            // 
            this.textBox93.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox93.Location = new System.Drawing.Point(108, 47);
            this.textBox93.Name = "textBox93";
            this.textBox93.Size = new System.Drawing.Size(67, 26);
            this.textBox93.TabIndex = 59;
            // 
            // label467
            // 
            this.label467.AutoSize = true;
            this.label467.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label467.Location = new System.Drawing.Point(9, 55);
            this.label467.Name = "label467";
            this.label467.Size = new System.Drawing.Size(94, 14);
            this.label467.TabIndex = 37;
            this.label467.Text = "Home Velocity";
            // 
            // groupBox110
            // 
            this.groupBox110.BackColor = System.Drawing.Color.White;
            this.groupBox110.Controls.Add(this.btnMotionStopS2);
            this.groupBox110.Controls.Add(this.btnMotionMoveS2);
            this.groupBox110.Controls.Add(this.label468);
            this.groupBox110.Controls.Add(this.label469);
            this.groupBox110.Controls.Add(this.txtShuttle2_TargetSpeed);
            this.groupBox110.Controls.Add(this.label470);
            this.groupBox110.Controls.Add(this.txtServoS2_Targetposition);
            this.groupBox110.Controls.Add(this.label471);
            this.groupBox110.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox110.Location = new System.Drawing.Point(247, 149);
            this.groupBox110.Name = "groupBox110";
            this.groupBox110.Size = new System.Drawing.Size(205, 168);
            this.groupBox110.TabIndex = 56;
            this.groupBox110.TabStop = false;
            this.groupBox110.Text = "Motion Control";
            // 
            // btnMotionStopS2
            // 
            this.btnMotionStopS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMotionStopS2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMotionStopS2.ForeColor = System.Drawing.Color.White;
            this.btnMotionStopS2.Location = new System.Drawing.Point(111, 111);
            this.btnMotionStopS2.Name = "btnMotionStopS2";
            this.btnMotionStopS2.Size = new System.Drawing.Size(83, 38);
            this.btnMotionStopS2.TabIndex = 73;
            this.btnMotionStopS2.Text = "Stop";
            this.btnMotionStopS2.UseVisualStyleBackColor = false;
            // 
            // btnMotionMoveS2
            // 
            this.btnMotionMoveS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMotionMoveS2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMotionMoveS2.ForeColor = System.Drawing.Color.White;
            this.btnMotionMoveS2.Location = new System.Drawing.Point(15, 111);
            this.btnMotionMoveS2.Name = "btnMotionMoveS2";
            this.btnMotionMoveS2.Size = new System.Drawing.Size(83, 38);
            this.btnMotionMoveS2.TabIndex = 70;
            this.btnMotionMoveS2.Text = "Move";
            this.btnMotionMoveS2.UseVisualStyleBackColor = false;
            // 
            // label468
            // 
            this.label468.AutoSize = true;
            this.label468.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label468.Location = new System.Drawing.Point(148, 79);
            this.label468.Name = "label468";
            this.label468.Size = new System.Drawing.Size(47, 14);
            this.label468.TabIndex = 67;
            this.label468.Text = "(mm/s)";
            // 
            // label469
            // 
            this.label469.AutoSize = true;
            this.label469.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label469.Location = new System.Drawing.Point(148, 37);
            this.label469.Name = "label469";
            this.label469.Size = new System.Drawing.Size(37, 14);
            this.label469.TabIndex = 66;
            this.label469.Text = "(mm)";
            // 
            // txtShuttle2_TargetSpeed
            // 
            this.txtShuttle2_TargetSpeed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShuttle2_TargetSpeed.Location = new System.Drawing.Point(75, 66);
            this.txtShuttle2_TargetSpeed.Name = "txtShuttle2_TargetSpeed";
            this.txtShuttle2_TargetSpeed.Size = new System.Drawing.Size(67, 26);
            this.txtShuttle2_TargetSpeed.TabIndex = 61;
            // 
            // label470
            // 
            this.label470.AutoSize = true;
            this.label470.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label470.Location = new System.Drawing.Point(14, 73);
            this.label470.Name = "label470";
            this.label470.Size = new System.Drawing.Size(45, 14);
            this.label470.TabIndex = 60;
            this.label470.Text = "Speed";
            // 
            // txtServoS2_Targetposition
            // 
            this.txtServoS2_Targetposition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServoS2_Targetposition.Location = new System.Drawing.Point(75, 29);
            this.txtServoS2_Targetposition.Name = "txtServoS2_Targetposition";
            this.txtServoS2_Targetposition.Size = new System.Drawing.Size(67, 26);
            this.txtServoS2_Targetposition.TabIndex = 59;
            // 
            // label471
            // 
            this.label471.AutoSize = true;
            this.label471.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label471.Location = new System.Drawing.Point(14, 36);
            this.label471.Name = "label471";
            this.label471.Size = new System.Drawing.Size(57, 14);
            this.label471.TabIndex = 37;
            this.label471.Text = "Position";
            // 
            // groupBox111
            // 
            this.groupBox111.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox111.Controls.Add(this.lblSh2servo_PositiveLimit);
            this.groupBox111.Controls.Add(this.label473);
            this.groupBox111.Controls.Add(this.lblSh2servo_NegativeLimit);
            this.groupBox111.Controls.Add(this.label475);
            this.groupBox111.Controls.Add(this.lblSh2servoDisable);
            this.groupBox111.Controls.Add(this.label477);
            this.groupBox111.Controls.Add(this.lblSh2servo_Error);
            this.groupBox111.Controls.Add(this.label479);
            this.groupBox111.Controls.Add(this.lblSh2servo_Home);
            this.groupBox111.Controls.Add(this.label481);
            this.groupBox111.Controls.Add(this.label482);
            this.groupBox111.Controls.Add(this.lblSh2servoenable);
            this.groupBox111.Controls.Add(this.label484);
            this.groupBox111.Controls.Add(this.label485);
            this.groupBox111.Controls.Add(this.label486);
            this.groupBox111.Controls.Add(this.label487);
            this.groupBox111.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox111.Location = new System.Drawing.Point(15, 14);
            this.groupBox111.Name = "groupBox111";
            this.groupBox111.Size = new System.Drawing.Size(687, 128);
            this.groupBox111.TabIndex = 37;
            this.groupBox111.TabStop = false;
            this.groupBox111.Text = "Device Status";
            // 
            // lblSh2servo_PositiveLimit
            // 
            this.lblSh2servo_PositiveLimit.BackColor = System.Drawing.Color.Maroon;
            this.lblSh2servo_PositiveLimit.Location = new System.Drawing.Point(639, 87);
            this.lblSh2servo_PositiveLimit.Name = "lblSh2servo_PositiveLimit";
            this.lblSh2servo_PositiveLimit.Size = new System.Drawing.Size(27, 26);
            this.lblSh2servo_PositiveLimit.TabIndex = 65;
            // 
            // label473
            // 
            this.label473.AutoSize = true;
            this.label473.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label473.Location = new System.Drawing.Point(545, 94);
            this.label473.Name = "label473";
            this.label473.Size = new System.Drawing.Size(89, 14);
            this.label473.TabIndex = 64;
            this.label473.Text = "Positive Limit";
            // 
            // lblSh2servo_NegativeLimit
            // 
            this.lblSh2servo_NegativeLimit.BackColor = System.Drawing.Color.Maroon;
            this.lblSh2servo_NegativeLimit.Location = new System.Drawing.Point(639, 33);
            this.lblSh2servo_NegativeLimit.Name = "lblSh2servo_NegativeLimit";
            this.lblSh2servo_NegativeLimit.Size = new System.Drawing.Size(27, 26);
            this.lblSh2servo_NegativeLimit.TabIndex = 63;
            // 
            // label475
            // 
            this.label475.AutoSize = true;
            this.label475.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label475.Location = new System.Drawing.Point(541, 41);
            this.label475.Name = "label475";
            this.label475.Size = new System.Drawing.Size(94, 14);
            this.label475.TabIndex = 62;
            this.label475.Text = "Negative Limit";
            // 
            // lblSh2servoDisable
            // 
            this.lblSh2servoDisable.BackColor = System.Drawing.Color.Maroon;
            this.lblSh2servoDisable.Location = new System.Drawing.Point(111, 84);
            this.lblSh2servoDisable.Name = "lblSh2servoDisable";
            this.lblSh2servoDisable.Size = new System.Drawing.Size(27, 26);
            this.lblSh2servoDisable.TabIndex = 61;
            // 
            // label477
            // 
            this.label477.AutoSize = true;
            this.label477.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label477.Location = new System.Drawing.Point(22, 93);
            this.label477.Name = "label477";
            this.label477.Size = new System.Drawing.Size(89, 14);
            this.label477.TabIndex = 60;
            this.label477.Text = "Servo Disable";
            // 
            // lblSh2servo_Error
            // 
            this.lblSh2servo_Error.BackColor = System.Drawing.Color.Maroon;
            this.lblSh2servo_Error.Location = new System.Drawing.Point(465, 84);
            this.lblSh2servo_Error.Name = "lblSh2servo_Error";
            this.lblSh2servo_Error.Size = new System.Drawing.Size(27, 26);
            this.lblSh2servo_Error.TabIndex = 58;
            // 
            // label479
            // 
            this.label479.AutoSize = true;
            this.label479.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label479.Location = new System.Drawing.Point(371, 93);
            this.label479.Name = "label479";
            this.label479.Size = new System.Drawing.Size(93, 14);
            this.label479.TabIndex = 57;
            this.label479.Text = "Servo In Error";
            // 
            // lblSh2servo_Home
            // 
            this.lblSh2servo_Home.BackColor = System.Drawing.Color.Maroon;
            this.lblSh2servo_Home.Location = new System.Drawing.Point(465, 33);
            this.lblSh2servo_Home.Name = "lblSh2servo_Home";
            this.lblSh2servo_Home.Size = new System.Drawing.Size(27, 26);
            this.lblSh2servo_Home.TabIndex = 48;
            // 
            // label481
            // 
            this.label481.BackColor = System.Drawing.Color.Maroon;
            this.label481.Location = new System.Drawing.Point(291, 84);
            this.label481.Name = "label481";
            this.label481.Size = new System.Drawing.Size(27, 26);
            this.label481.TabIndex = 47;
            // 
            // label482
            // 
            this.label482.BackColor = System.Drawing.Color.Maroon;
            this.label482.Location = new System.Drawing.Point(291, 29);
            this.label482.Name = "label482";
            this.label482.Size = new System.Drawing.Size(27, 26);
            this.label482.TabIndex = 46;
            // 
            // lblSh2servoenable
            // 
            this.lblSh2servoenable.BackColor = System.Drawing.Color.Maroon;
            this.lblSh2servoenable.Location = new System.Drawing.Point(111, 29);
            this.lblSh2servoenable.Name = "lblSh2servoenable";
            this.lblSh2servoenable.Size = new System.Drawing.Size(27, 26);
            this.lblSh2servoenable.TabIndex = 45;
            // 
            // label484
            // 
            this.label484.AutoSize = true;
            this.label484.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label484.Location = new System.Drawing.Point(191, 93);
            this.label484.Name = "label484";
            this.label484.Size = new System.Drawing.Size(98, 14);
            this.label484.TabIndex = 43;
            this.label484.Text = "Servo Running";
            // 
            // label485
            // 
            this.label485.AutoSize = true;
            this.label485.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label485.Location = new System.Drawing.Point(383, 41);
            this.label485.Name = "label485";
            this.label485.Size = new System.Drawing.Size(81, 14);
            this.label485.TabIndex = 41;
            this.label485.Text = "Servo Home";
            // 
            // label486
            // 
            this.label486.AutoSize = true;
            this.label486.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label486.Location = new System.Drawing.Point(206, 38);
            this.label486.Name = "label486";
            this.label486.Size = new System.Drawing.Size(84, 14);
            this.label486.TabIndex = 39;
            this.label486.Text = "Servo Ready";
            // 
            // label487
            // 
            this.label487.AutoSize = true;
            this.label487.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label487.Location = new System.Drawing.Point(22, 38);
            this.label487.Name = "label487";
            this.label487.Size = new System.Drawing.Size(86, 14);
            this.label487.TabIndex = 37;
            this.label487.Text = "Servo Enable";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 620);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPageAxis);
            this.tabControl2.Controls.Add(this.tabPageStepper);
            this.tabControl2.Controls.Add(this.tabPageCylinder);
            this.tabControl2.Controls.Add(this.tabPageVacuum);
            this.tabControl2.Controls.Add(this.tabPageRobot);
            this.tabControl2.Controls.Add(this.tabPageCamera);
            this.tabControl2.Controls.Add(this.tabPageLightControl);
            this.tabControl2.Controls.Add(this.tabPageScanner);
            this.tabControl2.Controls.Add(this.tabPageSfcPdca);
            this.tabControl2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(0, 0);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1018, 614);
            this.tabControl2.TabIndex = 9;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPageAxis
            // 
            this.tabPageAxis.BackColor = System.Drawing.Color.White;
            this.tabPageAxis.Controls.Add(this.ServosettingsPanel);
            this.tabPageAxis.Controls.Add(this.AxisSelectPanel);
            this.tabPageAxis.Location = new System.Drawing.Point(4, 27);
            this.tabPageAxis.Name = "tabPageAxis";
            this.tabPageAxis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAxis.Size = new System.Drawing.Size(1010, 583);
            this.tabPageAxis.TabIndex = 0;
            this.tabPageAxis.Text = "AXIS";
            // 
            // ServosettingsPanel
            // 
            this.ServosettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServosettingsPanel.Controls.Add(this.groupBox3);
            this.ServosettingsPanel.Location = new System.Drawing.Point(3, 64);
            this.ServosettingsPanel.Name = "ServosettingsPanel";
            this.ServosettingsPanel.Size = new System.Drawing.Size(1004, 519);
            this.ServosettingsPanel.TabIndex = 92;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.groupBox12);
            this.groupBox3.Controls.Add(this.richTextBoxStatus);
            this.groupBox3.Controls.Add(this.grbPTP);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox10);
            this.groupBox3.Controls.Add(this.groupBox11);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1004, 511);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox12.Controls.Add(this.lblServoHomedColor);
            this.groupBox12.Controls.Add(this.label34);
            this.groupBox12.Controls.Add(this.lblServoErrorColor);
            this.groupBox12.Controls.Add(this.label38);
            this.groupBox12.Controls.Add(this.lblPosLimColor);
            this.groupBox12.Controls.Add(this.label40);
            this.groupBox12.Controls.Add(this.lblServoHomeColor);
            this.groupBox12.Controls.Add(this.lblServoRunningColor);
            this.groupBox12.Controls.Add(this.lblNegLimitColor);
            this.groupBox12.Controls.Add(this.lblServoEnableColor);
            this.groupBox12.Controls.Add(this.label47);
            this.groupBox12.Controls.Add(this.label48);
            this.groupBox12.Controls.Add(this.label49);
            this.groupBox12.Controls.Add(this.label51);
            this.groupBox12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(9, 17);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(685, 128);
            this.groupBox12.TabIndex = 82;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Device Status";
            // 
            // lblServoHomedColor
            // 
            this.lblServoHomedColor.BackColor = System.Drawing.Color.Maroon;
            this.lblServoHomedColor.Location = new System.Drawing.Point(105, 85);
            this.lblServoHomedColor.Name = "lblServoHomedColor";
            this.lblServoHomedColor.Size = new System.Drawing.Size(27, 26);
            this.lblServoHomedColor.TabIndex = 63;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(14, 93);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(79, 14);
            this.label34.TabIndex = 62;
            this.label34.Text = "Axis Homed";
            // 
            // lblServoErrorColor
            // 
            this.lblServoErrorColor.BackColor = System.Drawing.Color.Maroon;
            this.lblServoErrorColor.Location = new System.Drawing.Point(278, 32);
            this.lblServoErrorColor.Name = "lblServoErrorColor";
            this.lblServoErrorColor.Size = new System.Drawing.Size(27, 26);
            this.lblServoErrorColor.TabIndex = 61;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(184, 40);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(83, 14);
            this.label38.TabIndex = 60;
            this.label38.Text = "Axis In Error";
            // 
            // lblPosLimColor
            // 
            this.lblPosLimColor.BackColor = System.Drawing.Color.Maroon;
            this.lblPosLimColor.Location = new System.Drawing.Point(436, 85);
            this.lblPosLimColor.Name = "lblPosLimColor";
            this.lblPosLimColor.Size = new System.Drawing.Size(27, 26);
            this.lblPosLimColor.TabIndex = 59;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(342, 93);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(89, 14);
            this.label40.TabIndex = 56;
            this.label40.Text = "Positive Limit";
            // 
            // lblServoHomeColor
            // 
            this.lblServoHomeColor.BackColor = System.Drawing.Color.Maroon;
            this.lblServoHomeColor.Location = new System.Drawing.Point(604, 32);
            this.lblServoHomeColor.Name = "lblServoHomeColor";
            this.lblServoHomeColor.Size = new System.Drawing.Size(27, 26);
            this.lblServoHomeColor.TabIndex = 48;
            // 
            // lblServoRunningColor
            // 
            this.lblServoRunningColor.BackColor = System.Drawing.Color.Maroon;
            this.lblServoRunningColor.Location = new System.Drawing.Point(278, 85);
            this.lblServoRunningColor.Name = "lblServoRunningColor";
            this.lblServoRunningColor.Size = new System.Drawing.Size(27, 26);
            this.lblServoRunningColor.TabIndex = 47;
            // 
            // lblNegLimitColor
            // 
            this.lblNegLimitColor.BackColor = System.Drawing.Color.Maroon;
            this.lblNegLimitColor.Location = new System.Drawing.Point(436, 32);
            this.lblNegLimitColor.Name = "lblNegLimitColor";
            this.lblNegLimitColor.Size = new System.Drawing.Size(27, 26);
            this.lblNegLimitColor.TabIndex = 45;
            // 
            // lblServoEnableColor
            // 
            this.lblServoEnableColor.BackColor = System.Drawing.Color.Maroon;
            this.lblServoEnableColor.Location = new System.Drawing.Point(105, 32);
            this.lblServoEnableColor.Name = "lblServoEnableColor";
            this.lblServoEnableColor.Size = new System.Drawing.Size(27, 26);
            this.lblServoEnableColor.TabIndex = 45;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(180, 93);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(88, 14);
            this.label47.TabIndex = 43;
            this.label47.Text = "Axis Running";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(522, 40);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 14);
            this.label48.TabIndex = 41;
            this.label48.Text = "Axis Home";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(337, 40);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(94, 14);
            this.label49.TabIndex = 37;
            this.label49.Text = "Negative Limit";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(15, 40);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(76, 14);
            this.label51.TabIndex = 37;
            this.label51.Text = "Axis Enable";
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Enabled = false;
            this.richTextBoxStatus.Location = new System.Drawing.Point(703, 342);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(291, 142);
            this.richTextBoxStatus.TabIndex = 81;
            this.richTextBoxStatus.Text = "";
            // 
            // grbPTP
            // 
            this.grbPTP.Controls.Add(this.btnPTP_Stop);
            this.grbPTP.Controls.Add(this.btnPTP_Move);
            this.grbPTP.Controls.Add(this.txtIteration);
            this.grbPTP.Controls.Add(this.txtWait);
            this.grbPTP.Controls.Add(this.txtPTP_Speed);
            this.grbPTP.Controls.Add(this.label93);
            this.grbPTP.Controls.Add(this.label94);
            this.grbPTP.Controls.Add(this.txtPTP_End);
            this.grbPTP.Controls.Add(this.label97);
            this.grbPTP.Controls.Add(this.txtPTP_Start);
            this.grbPTP.Controls.Add(this.label99);
            this.grbPTP.Controls.Add(this.label102);
            this.grbPTP.Controls.Add(this.label103);
            this.grbPTP.Controls.Add(this.label104);
            this.grbPTP.Controls.Add(this.label105);
            this.grbPTP.Controls.Add(this.label83);
            this.grbPTP.Controls.Add(this.label91);
            this.grbPTP.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPTP.Location = new System.Drawing.Point(9, 334);
            this.grbPTP.Name = "grbPTP";
            this.grbPTP.Size = new System.Drawing.Size(685, 150);
            this.grbPTP.TabIndex = 80;
            this.grbPTP.TabStop = false;
            this.grbPTP.Text = "Point To Point Control";
            // 
            // btnPTP_Stop
            // 
            this.btnPTP_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnPTP_Stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTP_Stop.ForeColor = System.Drawing.Color.White;
            this.btnPTP_Stop.Location = new System.Drawing.Point(371, 103);
            this.btnPTP_Stop.Name = "btnPTP_Stop";
            this.btnPTP_Stop.Size = new System.Drawing.Size(83, 37);
            this.btnPTP_Stop.TabIndex = 71;
            this.btnPTP_Stop.Text = "Stop";
            this.btnPTP_Stop.UseVisualStyleBackColor = false;
            this.btnPTP_Stop.Click += new System.EventHandler(this.btnPTP_Stop_Click);
            // 
            // btnPTP_Move
            // 
            this.btnPTP_Move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnPTP_Move.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTP_Move.ForeColor = System.Drawing.Color.White;
            this.btnPTP_Move.Location = new System.Drawing.Point(174, 103);
            this.btnPTP_Move.Name = "btnPTP_Move";
            this.btnPTP_Move.Size = new System.Drawing.Size(83, 37);
            this.btnPTP_Move.TabIndex = 70;
            this.btnPTP_Move.Text = "Move";
            this.btnPTP_Move.UseVisualStyleBackColor = false;
            this.btnPTP_Move.Click += new System.EventHandler(this.btnPTP_Move_Click);
            // 
            // txtIteration
            // 
            this.txtIteration.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIteration.Location = new System.Drawing.Point(545, 28);
            this.txtIteration.Name = "txtIteration";
            this.txtIteration.Size = new System.Drawing.Size(66, 26);
            this.txtIteration.TabIndex = 61;
            this.txtIteration.Text = "1";
            this.txtIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIteration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIteration_KeyDown);
            this.txtIteration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIteration_KeyPress);
            this.txtIteration.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtIteration_MouseDown);
            this.txtIteration.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtIteration_MouseUp);
            // 
            // txtWait
            // 
            this.txtWait.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWait.Location = new System.Drawing.Point(312, 65);
            this.txtWait.Name = "txtWait";
            this.txtWait.Size = new System.Drawing.Size(66, 26);
            this.txtWait.TabIndex = 61;
            this.txtWait.Text = "1";
            this.txtWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWait.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWait_KeyDown);
            this.txtWait.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWait_KeyPress);
            this.txtWait.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtWait_MouseDown);
            this.txtWait.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtWait_MouseUp);
            // 
            // txtPTP_Speed
            // 
            this.txtPTP_Speed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPTP_Speed.Location = new System.Drawing.Point(312, 28);
            this.txtPTP_Speed.Name = "txtPTP_Speed";
            this.txtPTP_Speed.Size = new System.Drawing.Size(66, 26);
            this.txtPTP_Speed.TabIndex = 61;
            this.txtPTP_Speed.Text = "1";
            this.txtPTP_Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPTP_Speed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPTP_Speed_KeyDown);
            this.txtPTP_Speed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPTP_Speed_KeyPress);
            this.txtPTP_Speed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtPTP_Speed_MouseDown);
            this.txtPTP_Speed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtPTP_Speed_MouseUp);
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.Location = new System.Drawing.Point(20, 77);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(84, 14);
            this.label93.TabIndex = 37;
            this.label93.Text = "End Position";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.Location = new System.Drawing.Point(12, 37);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(93, 14);
            this.label94.TabIndex = 37;
            this.label94.Text = "Start Position";
            // 
            // txtPTP_End
            // 
            this.txtPTP_End.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPTP_End.Location = new System.Drawing.Point(106, 72);
            this.txtPTP_End.Name = "txtPTP_End";
            this.txtPTP_End.Size = new System.Drawing.Size(66, 26);
            this.txtPTP_End.TabIndex = 59;
            this.txtPTP_End.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPTP_End.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPTP_End_KeyDown);
            this.txtPTP_End.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPTP_End_KeyPress);
            this.txtPTP_End.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtPTP_End_MouseDown);
            this.txtPTP_End.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtPTP_End_MouseUp);
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.Location = new System.Drawing.Point(480, 37);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(62, 14);
            this.label97.TabIndex = 60;
            this.label97.Text = "Iteration";
            // 
            // txtPTP_Start
            // 
            this.txtPTP_Start.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPTP_Start.Location = new System.Drawing.Point(106, 32);
            this.txtPTP_Start.Name = "txtPTP_Start";
            this.txtPTP_Start.Size = new System.Drawing.Size(66, 26);
            this.txtPTP_Start.TabIndex = 59;
            this.txtPTP_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPTP_Start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPTP_Start_KeyDown);
            this.txtPTP_Start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPTP_Start_KeyPress);
            this.txtPTP_Start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtPTP_Start_MouseDown);
            this.txtPTP_Start.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtPTP_Start_MouseUp);
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.Location = new System.Drawing.Point(271, 74);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(35, 14);
            this.label99.TabIndex = 60;
            this.label99.Text = "Wait";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.Location = new System.Drawing.Point(178, 77);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(37, 14);
            this.label102.TabIndex = 66;
            this.label102.Text = "(mm)";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label103.Location = new System.Drawing.Point(617, 37);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(39, 14);
            this.label103.TabIndex = 67;
            this.label103.Text = "count";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label104.Location = new System.Drawing.Point(262, 37);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(45, 14);
            this.label104.TabIndex = 60;
            this.label104.Text = "Speed";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.Location = new System.Drawing.Point(384, 74);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(25, 14);
            this.label105.TabIndex = 67;
            this.label105.Text = "sec";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.Location = new System.Drawing.Point(178, 37);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(37, 14);
            this.label83.TabIndex = 66;
            this.label83.Text = "(mm)";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.Location = new System.Drawing.Point(384, 37);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(47, 14);
            this.label91.TabIndex = 67;
            this.label91.Text = "(mm/s)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnServoEnable);
            this.groupBox5.Controls.Add(this.btnServoClear);
            this.groupBox5.Controls.Add(this.btnServoDisable);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(9, 148);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(182, 168);
            this.groupBox5.TabIndex = 75;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Device Control";
            // 
            // btnServoEnable
            // 
            this.btnServoEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnServoEnable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServoEnable.ForeColor = System.Drawing.Color.White;
            this.btnServoEnable.Location = new System.Drawing.Point(16, 25);
            this.btnServoEnable.Name = "btnServoEnable";
            this.btnServoEnable.Size = new System.Drawing.Size(147, 38);
            this.btnServoEnable.TabIndex = 71;
            this.btnServoEnable.Text = "Axis Enable";
            this.btnServoEnable.UseVisualStyleBackColor = false;
            this.btnServoEnable.Click += new System.EventHandler(this.btnServoEnable_Click);
            // 
            // btnServoClear
            // 
            this.btnServoClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnServoClear.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServoClear.ForeColor = System.Drawing.Color.White;
            this.btnServoClear.Location = new System.Drawing.Point(16, 113);
            this.btnServoClear.Name = "btnServoClear";
            this.btnServoClear.Size = new System.Drawing.Size(147, 38);
            this.btnServoClear.TabIndex = 71;
            this.btnServoClear.Text = "Axis Clear Error";
            this.btnServoClear.UseVisualStyleBackColor = false;
            this.btnServoClear.Click += new System.EventHandler(this.btnServoClear_Click);
            // 
            // btnServoDisable
            // 
            this.btnServoDisable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnServoDisable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServoDisable.ForeColor = System.Drawing.Color.White;
            this.btnServoDisable.Location = new System.Drawing.Point(16, 69);
            this.btnServoDisable.Name = "btnServoDisable";
            this.btnServoDisable.Size = new System.Drawing.Size(147, 38);
            this.btnServoDisable.TabIndex = 71;
            this.btnServoDisable.Text = "Axis Disable";
            this.btnServoDisable.UseVisualStyleBackColor = false;
            this.btnServoDisable.Click += new System.EventHandler(this.btnServoDisable_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.lbl_Servo_Actual_Position);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.lbl_Servo_TargetPosition);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(703, 14);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(291, 128);
            this.groupBox6.TabIndex = 74;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Live Values";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 73;
            this.label3.Text = "(mm)";
            // 
            // lbl_Servo_Actual_Position
            // 
            this.lbl_Servo_Actual_Position.AutoSize = true;
            this.lbl_Servo_Actual_Position.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Servo_Actual_Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Servo_Actual_Position.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Servo_Actual_Position.Location = new System.Drawing.Point(180, 42);
            this.lbl_Servo_Actual_Position.Name = "lbl_Servo_Actual_Position";
            this.lbl_Servo_Actual_Position.Size = new System.Drawing.Size(18, 16);
            this.lbl_Servo_Actual_Position.TabIndex = 53;
            this.lbl_Servo_Actual_Position.Text = "0";
            this.lbl_Servo_Actual_Position.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 75;
            this.label5.Text = "(mm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 14);
            this.label7.TabIndex = 52;
            this.label7.Text = "Axis Actual Position";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 14);
            this.label9.TabIndex = 54;
            this.label9.Text = "Axis Target Position";
            // 
            // lbl_Servo_TargetPosition
            // 
            this.lbl_Servo_TargetPosition.AutoSize = true;
            this.lbl_Servo_TargetPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Servo_TargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Servo_TargetPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Servo_TargetPosition.Location = new System.Drawing.Point(180, 83);
            this.lbl_Servo_TargetPosition.Name = "lbl_Servo_TargetPosition";
            this.lbl_Servo_TargetPosition.Size = new System.Drawing.Size(18, 16);
            this.lbl_Servo_TargetPosition.TabIndex = 55;
            this.lbl_Servo_TargetPosition.Text = "0";
            this.lbl_Servo_TargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.White;
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.txtJogSpeed);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.btnJogReverse);
            this.groupBox8.Controls.Add(this.btnJogForward);
            this.groupBox8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(703, 148);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(291, 165);
            this.groupBox8.TabIndex = 72;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Jog Control";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(204, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 14);
            this.label4.TabIndex = 77;
            this.label4.Text = "(mm/s)";
            // 
            // txtJogSpeed
            // 
            this.txtJogSpeed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJogSpeed.Location = new System.Drawing.Point(126, 54);
            this.txtJogSpeed.Name = "txtJogSpeed";
            this.txtJogSpeed.Size = new System.Drawing.Size(67, 26);
            this.txtJogSpeed.TabIndex = 76;
            this.txtJogSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJogSpeed_KeyDown);
            this.txtJogSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJogSpeed_KeyPress);
            this.txtJogSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtJogSpeed_MouseDown);
            this.txtJogSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtJogSpeed_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(44, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 14);
            this.label10.TabIndex = 75;
            this.label10.Text = "Speed";
            // 
            // btnJogReverse
            // 
            this.btnJogReverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogReverse.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogReverse.ForeColor = System.Drawing.Color.White;
            this.btnJogReverse.Location = new System.Drawing.Point(176, 107);
            this.btnJogReverse.Name = "btnJogReverse";
            this.btnJogReverse.Size = new System.Drawing.Size(83, 38);
            this.btnJogReverse.TabIndex = 74;
            this.btnJogReverse.Text = "Jog -";
            this.btnJogReverse.UseVisualStyleBackColor = false;
            this.btnJogReverse.Click += new System.EventHandler(this.button44_Click);
            this.btnJogReverse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogReverse_MouseDown);
            this.btnJogReverse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogReverse_MouseUp);
            // 
            // btnJogForward
            // 
            this.btnJogForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnJogForward.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogForward.ForeColor = System.Drawing.Color.White;
            this.btnJogForward.Location = new System.Drawing.Point(49, 107);
            this.btnJogForward.Name = "btnJogForward";
            this.btnJogForward.Size = new System.Drawing.Size(83, 38);
            this.btnJogForward.TabIndex = 73;
            this.btnJogForward.Text = "Jog +";
            this.btnJogForward.UseVisualStyleBackColor = false;
            this.btnJogForward.Click += new System.EventHandler(this.button45_Click);
            this.btnJogForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogForward_MouseDown);
            this.btnJogForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogForward_MouseUp);
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.White;
            this.groupBox10.Controls.Add(this.btnHomeStop);
            this.groupBox10.Controls.Add(this.label26);
            this.groupBox10.Controls.Add(this.btnHome);
            this.groupBox10.Controls.Add(this.txtHome_Velocity);
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(454, 151);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(240, 165);
            this.groupBox10.TabIndex = 71;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Homing Control";
            // 
            // btnHomeStop
            // 
            this.btnHomeStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeStop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeStop.ForeColor = System.Drawing.Color.White;
            this.btnHomeStop.Location = new System.Drawing.Point(143, 105);
            this.btnHomeStop.Name = "btnHomeStop";
            this.btnHomeStop.Size = new System.Drawing.Size(83, 38);
            this.btnHomeStop.TabIndex = 72;
            this.btnHomeStop.Text = "Stop";
            this.btnHomeStop.UseVisualStyleBackColor = false;
            this.btnHomeStop.Click += new System.EventHandler(this.btnHomeStop_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(179, 55);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 14);
            this.label26.TabIndex = 72;
            this.label26.Text = "(mm/s)";
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHome.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(23, 105);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(83, 38);
            this.btnHome.TabIndex = 72;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // txtHome_Velocity
            // 
            this.txtHome_Velocity.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHome_Velocity.Location = new System.Drawing.Point(108, 47);
            this.txtHome_Velocity.Name = "txtHome_Velocity";
            this.txtHome_Velocity.Size = new System.Drawing.Size(67, 26);
            this.txtHome_Velocity.TabIndex = 59;
            this.txtHome_Velocity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHome_Velocity_KeyDown);
            this.txtHome_Velocity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHome_Velocity_KeyPress);
            this.txtHome_Velocity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtHome_Velocity_MouseDown);
            this.txtHome_Velocity.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtHome_Velocity_MouseUp);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(9, 55);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(94, 14);
            this.label27.TabIndex = 37;
            this.label27.Text = "Home Velocity";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.White;
            this.groupBox11.Controls.Add(this.btnMoveStop);
            this.groupBox11.Controls.Add(this.btnMove);
            this.groupBox11.Controls.Add(this.label28);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Controls.Add(this.txtServoX_Targetspeed);
            this.groupBox11.Controls.Add(this.label30);
            this.groupBox11.Controls.Add(this.txtServoX_Targetposition);
            this.groupBox11.Controls.Add(this.label31);
            this.groupBox11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(203, 148);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(240, 168);
            this.groupBox11.TabIndex = 56;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Motion Control";
            // 
            // btnMoveStop
            // 
            this.btnMoveStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMoveStop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveStop.ForeColor = System.Drawing.Color.White;
            this.btnMoveStop.Location = new System.Drawing.Point(132, 107);
            this.btnMoveStop.Name = "btnMoveStop";
            this.btnMoveStop.Size = new System.Drawing.Size(83, 38);
            this.btnMoveStop.TabIndex = 72;
            this.btnMoveStop.Text = "Stop";
            this.btnMoveStop.UseVisualStyleBackColor = false;
            this.btnMoveStop.Click += new System.EventHandler(this.btnMoveStop_Click);
            // 
            // btnMove
            // 
            this.btnMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMove.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove.ForeColor = System.Drawing.Color.White;
            this.btnMove.Location = new System.Drawing.Point(21, 107);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(83, 38);
            this.btnMove.TabIndex = 70;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.button51_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(178, 76);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(47, 14);
            this.label28.TabIndex = 67;
            this.label28.Text = "(mm/s)";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(178, 39);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(37, 14);
            this.label29.TabIndex = 66;
            this.label29.Text = "(mm)";
            // 
            // txtServoX_Targetspeed
            // 
            this.txtServoX_Targetspeed.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServoX_Targetspeed.Location = new System.Drawing.Point(104, 68);
            this.txtServoX_Targetspeed.Name = "txtServoX_Targetspeed";
            this.txtServoX_Targetspeed.Size = new System.Drawing.Size(67, 26);
            this.txtServoX_Targetspeed.TabIndex = 61;
            this.txtServoX_Targetspeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtServoX_Targetspeed_KeyDown);
            this.txtServoX_Targetspeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServoX_Targetspeed_KeyPress);
            this.txtServoX_Targetspeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtServoX_Targetspeed_MouseDown);
            this.txtServoX_Targetspeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtServoX_Targetspeed_MouseUp);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(22, 73);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(45, 14);
            this.label30.TabIndex = 60;
            this.label30.Text = "Speed";
            // 
            // txtServoX_Targetposition
            // 
            this.txtServoX_Targetposition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServoX_Targetposition.Location = new System.Drawing.Point(104, 31);
            this.txtServoX_Targetposition.Name = "txtServoX_Targetposition";
            this.txtServoX_Targetposition.Size = new System.Drawing.Size(67, 26);
            this.txtServoX_Targetposition.TabIndex = 59;
            this.txtServoX_Targetposition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtServoX_Targetposition_KeyDown);
            this.txtServoX_Targetposition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServoX_Targetposition_KeyPress);
            this.txtServoX_Targetposition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtServoX_Targetposition_MouseDown);
            this.txtServoX_Targetposition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtServoX_Targetposition_MouseUp);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(22, 36);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(57, 14);
            this.label31.TabIndex = 37;
            this.label31.Text = "Position";
            // 
            // AxisSelectPanel
            // 
            this.AxisSelectPanel.Controls.Add(this.label2);
            this.AxisSelectPanel.Controls.Add(this.AxisSelectCombo);
            this.AxisSelectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AxisSelectPanel.Location = new System.Drawing.Point(3, 3);
            this.AxisSelectPanel.Name = "AxisSelectPanel";
            this.AxisSelectPanel.Size = new System.Drawing.Size(1004, 60);
            this.AxisSelectPanel.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 97;
            this.label2.Text = "Axis";
            // 
            // AxisSelectCombo
            // 
            this.AxisSelectCombo.AllowDrop = true;
            this.AxisSelectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AxisSelectCombo.FormattingEnabled = true;
            this.AxisSelectCombo.Items.AddRange(new object[] {
            "X1 - Axis",
            "Y1 - Axis",
            "Z1 - Axis"});
            this.AxisSelectCombo.Location = new System.Drawing.Point(58, 17);
            this.AxisSelectCombo.Name = "AxisSelectCombo";
            this.AxisSelectCombo.Size = new System.Drawing.Size(213, 26);
            this.AxisSelectCombo.TabIndex = 96;
            this.AxisSelectCombo.SelectedIndexChanged += new System.EventHandler(this.AxisSelectCombo_SelectedIndexChanged);
            // 
            // tabPageStepper
            // 
            this.tabPageStepper.Controls.Add(this.groupBox13);
            this.tabPageStepper.Controls.Add(this.panel1);
            this.tabPageStepper.Location = new System.Drawing.Point(4, 27);
            this.tabPageStepper.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageStepper.Name = "tabPageStepper";
            this.tabPageStepper.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageStepper.Size = new System.Drawing.Size(1010, 583);
            this.tabPageStepper.TabIndex = 13;
            this.tabPageStepper.Text = "STEPPER";
            this.tabPageStepper.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.White;
            this.groupBox13.Controls.Add(this.grp_IO_Conv);
            this.groupBox13.Controls.Add(this.groupBox15);
            this.groupBox13.Controls.Add(this.grp_IO_Conv_Stepper_2);
            this.groupBox13.Controls.Add(this.grp_IO_Conv_Stepper_1);
            this.groupBox13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(3, 67);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(1004, 511);
            this.groupBox13.TabIndex = 93;
            this.groupBox13.TabStop = false;
            // 
            // grp_IO_Conv
            // 
            this.grp_IO_Conv.BackColor = System.Drawing.Color.Transparent;
            this.grp_IO_Conv.Controls.Add(this.groupBox41);
            this.grp_IO_Conv.Controls.Add(this.groupBox42);
            this.grp_IO_Conv.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_IO_Conv.Location = new System.Drawing.Point(334, 22);
            this.grp_IO_Conv.Name = "grp_IO_Conv";
            this.grp_IO_Conv.Size = new System.Drawing.Size(343, 325);
            this.grp_IO_Conv.TabIndex = 87;
            this.grp_IO_Conv.TabStop = false;
            // 
            // groupBox41
            // 
            this.groupBox41.BackColor = System.Drawing.Color.Silver;
            this.groupBox41.Controls.Add(this.Conv_Status);
            this.groupBox41.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox41.Location = new System.Drawing.Point(56, 25);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(224, 80);
            this.groupBox41.TabIndex = 84;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "Device Status";
            // 
            // Conv_Status
            // 
            this.Conv_Status.BackColor = System.Drawing.Color.White;
            this.Conv_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Conv_Status.Enabled = false;
            this.Conv_Status.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conv_Status.ForeColor = System.Drawing.Color.Black;
            this.Conv_Status.Location = new System.Drawing.Point(8, 29);
            this.Conv_Status.Margin = new System.Windows.Forms.Padding(2);
            this.Conv_Status.Name = "Conv_Status";
            this.Conv_Status.ReadOnly = true;
            this.Conv_Status.Size = new System.Drawing.Size(206, 38);
            this.Conv_Status.TabIndex = 86;
            this.Conv_Status.Text = "Ready";
            this.Conv_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox42
            // 
            this.groupBox42.BackColor = System.Drawing.Color.Transparent;
            this.groupBox42.Controls.Add(this.Conv_Reset);
            this.groupBox42.Controls.Add(this.Conv_Reverse);
            this.groupBox42.Controls.Add(this.Conv_Stop);
            this.groupBox42.Controls.Add(this.Conv_Forward);
            this.groupBox42.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox42.Location = new System.Drawing.Point(61, 144);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Size = new System.Drawing.Size(224, 141);
            this.groupBox42.TabIndex = 83;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "Motion Control";
            // 
            // Conv_Reset
            // 
            this.Conv_Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Conv_Reset.Font = new System.Drawing.Font("Cambria", 12F);
            this.Conv_Reset.ForeColor = System.Drawing.Color.White;
            this.Conv_Reset.Location = new System.Drawing.Point(112, 81);
            this.Conv_Reset.Name = "Conv_Reset";
            this.Conv_Reset.Size = new System.Drawing.Size(96, 38);
            this.Conv_Reset.TabIndex = 11;
            this.Conv_Reset.Text = "Reset";
            this.Conv_Reset.UseVisualStyleBackColor = false;
            this.Conv_Reset.Click += new System.EventHandler(this.Conv_Reset_Click);
            // 
            // Conv_Reverse
            // 
            this.Conv_Reverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Conv_Reverse.Font = new System.Drawing.Font("Cambria", 12F);
            this.Conv_Reverse.ForeColor = System.Drawing.Color.White;
            this.Conv_Reverse.Location = new System.Drawing.Point(112, 28);
            this.Conv_Reverse.Name = "Conv_Reverse";
            this.Conv_Reverse.Size = new System.Drawing.Size(96, 38);
            this.Conv_Reverse.TabIndex = 10;
            this.Conv_Reverse.Text = "Reverse->";
            this.Conv_Reverse.UseVisualStyleBackColor = false;
            this.Conv_Reverse.Click += new System.EventHandler(this.Conv_Reverse_Click);
            // 
            // Conv_Stop
            // 
            this.Conv_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Conv_Stop.Font = new System.Drawing.Font("Cambria", 12F);
            this.Conv_Stop.ForeColor = System.Drawing.Color.White;
            this.Conv_Stop.Location = new System.Drawing.Point(10, 81);
            this.Conv_Stop.Name = "Conv_Stop";
            this.Conv_Stop.Size = new System.Drawing.Size(96, 38);
            this.Conv_Stop.TabIndex = 1;
            this.Conv_Stop.Text = "Stop";
            this.Conv_Stop.UseVisualStyleBackColor = false;
            this.Conv_Stop.Click += new System.EventHandler(this.Conv_Stop_Click);
            // 
            // Conv_Forward
            // 
            this.Conv_Forward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.Conv_Forward.Font = new System.Drawing.Font("Cambria", 12F);
            this.Conv_Forward.ForeColor = System.Drawing.Color.White;
            this.Conv_Forward.Location = new System.Drawing.Point(10, 28);
            this.Conv_Forward.Name = "Conv_Forward";
            this.Conv_Forward.Size = new System.Drawing.Size(96, 38);
            this.Conv_Forward.TabIndex = 9;
            this.Conv_Forward.Text = "<-Forward";
            this.Conv_Forward.UseVisualStyleBackColor = false;
            this.Conv_Forward.Click += new System.EventHandler(this.Conv_Forward_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox15.Controls.Add(this.lblServoErrorColor_Stp);
            this.groupBox15.Controls.Add(this.label22);
            this.groupBox15.Controls.Add(this.lblServoEnableColor_Stp);
            this.groupBox15.Controls.Add(this.label46);
            this.groupBox15.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox15.Location = new System.Drawing.Point(334, 22);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(343, 94);
            this.groupBox15.TabIndex = 82;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Device Status";
            // 
            // lblServoErrorColor_Stp
            // 
            this.lblServoErrorColor_Stp.BackColor = System.Drawing.Color.Maroon;
            this.lblServoErrorColor_Stp.Location = new System.Drawing.Point(278, 32);
            this.lblServoErrorColor_Stp.Name = "lblServoErrorColor_Stp";
            this.lblServoErrorColor_Stp.Size = new System.Drawing.Size(27, 26);
            this.lblServoErrorColor_Stp.TabIndex = 61;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(184, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 14);
            this.label22.TabIndex = 60;
            this.label22.Text = "Axis In Error";
            // 
            // lblServoEnableColor_Stp
            // 
            this.lblServoEnableColor_Stp.BackColor = System.Drawing.Color.Maroon;
            this.lblServoEnableColor_Stp.Location = new System.Drawing.Point(105, 32);
            this.lblServoEnableColor_Stp.Name = "lblServoEnableColor_Stp";
            this.lblServoEnableColor_Stp.Size = new System.Drawing.Size(27, 26);
            this.lblServoEnableColor_Stp.TabIndex = 45;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(15, 40);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(76, 14);
            this.label46.TabIndex = 37;
            this.label46.Text = "Axis Enable";
            // 
            // grp_IO_Conv_Stepper_2
            // 
            this.grp_IO_Conv_Stepper_2.Controls.Add(this.StpperServo_On);
            this.grp_IO_Conv_Stepper_2.Controls.Add(this.button37);
            this.grp_IO_Conv_Stepper_2.Controls.Add(this.button38);
            this.grp_IO_Conv_Stepper_2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_IO_Conv_Stepper_2.Location = new System.Drawing.Point(334, 359);
            this.grp_IO_Conv_Stepper_2.Name = "grp_IO_Conv_Stepper_2";
            this.grp_IO_Conv_Stepper_2.Size = new System.Drawing.Size(343, 96);
            this.grp_IO_Conv_Stepper_2.TabIndex = 75;
            this.grp_IO_Conv_Stepper_2.TabStop = false;
            this.grp_IO_Conv_Stepper_2.Text = "Device Control";
            // 
            // StpperServo_On
            // 
            this.StpperServo_On.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.StpperServo_On.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StpperServo_On.ForeColor = System.Drawing.Color.White;
            this.StpperServo_On.Location = new System.Drawing.Point(16, 25);
            this.StpperServo_On.Name = "StpperServo_On";
            this.StpperServo_On.Size = new System.Drawing.Size(86, 55);
            this.StpperServo_On.TabIndex = 71;
            this.StpperServo_On.Text = "Axis Enable";
            this.StpperServo_On.UseVisualStyleBackColor = false;
            this.StpperServo_On.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button37.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button37.ForeColor = System.Drawing.Color.White;
            this.button37.Location = new System.Drawing.Point(187, 25);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(88, 55);
            this.button37.TabIndex = 71;
            this.button37.Text = "Axis Clear Error";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button38.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button38.ForeColor = System.Drawing.Color.White;
            this.button38.Location = new System.Drawing.Point(108, 25);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(73, 55);
            this.button38.TabIndex = 71;
            this.button38.Text = "Axis Disable";
            this.button38.UseVisualStyleBackColor = false;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // grp_IO_Conv_Stepper_1
            // 
            this.grp_IO_Conv_Stepper_1.BackColor = System.Drawing.Color.White;
            this.grp_IO_Conv_Stepper_1.Controls.Add(this.button20);
            this.grp_IO_Conv_Stepper_1.Controls.Add(this.label80);
            this.grp_IO_Conv_Stepper_1.Controls.Add(this.stp_Text);
            this.grp_IO_Conv_Stepper_1.Controls.Add(this.label92);
            this.grp_IO_Conv_Stepper_1.Controls.Add(this.button44);
            this.grp_IO_Conv_Stepper_1.Controls.Add(this.button45);
            this.grp_IO_Conv_Stepper_1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_IO_Conv_Stepper_1.Location = new System.Drawing.Point(334, 122);
            this.grp_IO_Conv_Stepper_1.Name = "grp_IO_Conv_Stepper_1";
            this.grp_IO_Conv_Stepper_1.Size = new System.Drawing.Size(343, 231);
            this.grp_IO_Conv_Stepper_1.TabIndex = 72;
            this.grp_IO_Conv_Stepper_1.TabStop = false;
            this.grp_IO_Conv_Stepper_1.Text = "Jog Control";
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button20.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(126, 162);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(83, 38);
            this.button20.TabIndex = 78;
            this.button20.Text = "Stop";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.Stop_Cmd);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.Location = new System.Drawing.Point(204, 61);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(47, 14);
            this.label80.TabIndex = 77;
            this.label80.Text = "(mm/s)";
            // 
            // stp_Text
            // 
            this.stp_Text.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stp_Text.Location = new System.Drawing.Point(126, 54);
            this.stp_Text.Name = "stp_Text";
            this.stp_Text.Size = new System.Drawing.Size(67, 26);
            this.stp_Text.TabIndex = 76;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.Location = new System.Drawing.Point(44, 59);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(45, 14);
            this.label92.TabIndex = 75;
            this.label92.Text = "Speed";
            // 
            // button44
            // 
            this.button44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button44.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button44.ForeColor = System.Drawing.Color.White;
            this.button44.Location = new System.Drawing.Point(176, 107);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(94, 38);
            this.button44.TabIndex = 74;
            this.button44.Text = "Backword";
            this.button44.UseVisualStyleBackColor = false;
            this.button44.Click += new System.EventHandler(this.BackWord_Cmd);
            // 
            // button45
            // 
            this.button45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button45.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button45.ForeColor = System.Drawing.Color.White;
            this.button45.Location = new System.Drawing.Point(49, 107);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(99, 38);
            this.button45.TabIndex = 73;
            this.button45.Text = "Forword";
            this.button45.UseVisualStyleBackColor = false;
            this.button45.Click += new System.EventHandler(this.Froward_Cmd);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbConveyorStepperCombo);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.StepperAxisComb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 58);
            this.panel1.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(312, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 18);
            this.label12.TabIndex = 97;
            this.label12.Text = "Convyor";
            // 
            // StepperAxisComb
            // 
            this.StepperAxisComb.AllowDrop = true;
            this.StepperAxisComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StepperAxisComb.FormattingEnabled = true;
            this.StepperAxisComb.Items.AddRange(new object[] {
            "X1 - Axis",
            "Y1 - Axis",
            "Z1 - Axis"});
            this.StepperAxisComb.Location = new System.Drawing.Point(396, 17);
            this.StepperAxisComb.Name = "StepperAxisComb";
            this.StepperAxisComb.Size = new System.Drawing.Size(213, 26);
            this.StepperAxisComb.TabIndex = 96;
            this.StepperAxisComb.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // tabPageCylinder
            // 
            this.tabPageCylinder.BackColor = System.Drawing.Color.White;
            this.tabPageCylinder.Controls.Add(this.PnlCylinderMain);
            this.tabPageCylinder.Location = new System.Drawing.Point(4, 27);
            this.tabPageCylinder.Name = "tabPageCylinder";
            this.tabPageCylinder.Size = new System.Drawing.Size(1010, 583);
            this.tabPageCylinder.TabIndex = 6;
            this.tabPageCylinder.Text = "CYLINDERS";
            // 
            // PnlCylinderMain
            // 
            this.PnlCylinderMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlCylinderMain.Location = new System.Drawing.Point(0, 0);
            this.PnlCylinderMain.Name = "PnlCylinderMain";
            this.PnlCylinderMain.Size = new System.Drawing.Size(1010, 583);
            this.PnlCylinderMain.TabIndex = 0;
            // 
            // tabPageVacuum
            // 
            this.tabPageVacuum.Controls.Add(this.PnlVacuumMain);
            this.tabPageVacuum.Location = new System.Drawing.Point(4, 27);
            this.tabPageVacuum.Name = "tabPageVacuum";
            this.tabPageVacuum.Size = new System.Drawing.Size(1010, 583);
            this.tabPageVacuum.TabIndex = 7;
            this.tabPageVacuum.Text = "VACUUM";
            this.tabPageVacuum.UseVisualStyleBackColor = true;
            // 
            // PnlVacuumMain
            // 
            this.PnlVacuumMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlVacuumMain.Location = new System.Drawing.Point(0, 0);
            this.PnlVacuumMain.Name = "PnlVacuumMain";
            this.PnlVacuumMain.Size = new System.Drawing.Size(1010, 583);
            this.PnlVacuumMain.TabIndex = 1;
            this.PnlVacuumMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlVacuumMain_Paint);
            // 
            // tabPageRobot
            // 
            this.tabPageRobot.Controls.Add(this.panel2);
            this.tabPageRobot.Location = new System.Drawing.Point(4, 27);
            this.tabPageRobot.Name = "tabPageRobot";
            this.tabPageRobot.Size = new System.Drawing.Size(1010, 583);
            this.tabPageRobot.TabIndex = 8;
            this.tabPageRobot.Text = "ROBOT";
            this.tabPageRobot.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpRoboConn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1010, 583);
            this.panel2.TabIndex = 2;
            // 
            // grpRoboConn
            // 
            this.grpRoboConn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRoboConn.Controls.Add(this.btnDisConnect);
            this.grpRoboConn.Controls.Add(this.lblCmd);
            this.grpRoboConn.Controls.Add(this.cmbRBTmodeselect);
            this.grpRoboConn.Controls.Add(this.lblrobotconnstatus);
            this.grpRoboConn.Controls.Add(this.lblConnStatus);
            this.grpRoboConn.Controls.Add(this.btnconnect);
            this.grpRoboConn.Controls.Add(this.txtsendrobotcommand);
            this.grpRoboConn.Controls.Add(this.txtreceivecommnd);
            this.grpRoboConn.Controls.Add(this.label374);
            this.grpRoboConn.Controls.Add(this.btnRBTtrigger);
            this.grpRoboConn.Controls.Add(this.label376);
            this.grpRoboConn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRoboConn.Location = new System.Drawing.Point(533, 5);
            this.grpRoboConn.Name = "grpRoboConn";
            this.grpRoboConn.Size = new System.Drawing.Size(510, 553);
            this.grpRoboConn.TabIndex = 168;
            this.grpRoboConn.TabStop = false;
            this.grpRoboConn.Text = "Robot";
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnDisConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisConnect.ForeColor = System.Drawing.Color.White;
            this.btnDisConnect.Location = new System.Drawing.Point(183, 501);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(110, 35);
            this.btnDisConnect.TabIndex = 176;
            this.btnDisConnect.Text = "Disconnect";
            this.btnDisConnect.UseVisualStyleBackColor = false;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // lblCmd
            // 
            this.lblCmd.AutoSize = true;
            this.lblCmd.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmd.Location = new System.Drawing.Point(22, 33);
            this.lblCmd.Name = "lblCmd";
            this.lblCmd.Size = new System.Drawing.Size(98, 16);
            this.lblCmd.TabIndex = 175;
            this.lblCmd.Text = "Select Cmd :";
            // 
            // cmbRBTmodeselect
            // 
            this.cmbRBTmodeselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRBTmodeselect.FormattingEnabled = true;
            this.cmbRBTmodeselect.Items.AddRange(new object[] {
            "AUTO_MODE",
            "MANUAL_MODE",
            "INITIALIZATION_MODE",
            "CALIBRATION_MODE",
            "RECIPE_MODE"});
            this.cmbRBTmodeselect.Location = new System.Drawing.Point(126, 28);
            this.cmbRBTmodeselect.Name = "cmbRBTmodeselect";
            this.cmbRBTmodeselect.Size = new System.Drawing.Size(170, 26);
            this.cmbRBTmodeselect.TabIndex = 174;
            this.cmbRBTmodeselect.SelectedIndexChanged += new System.EventHandler(this.cmbRBTmodeselect_SelectedIndexChanged);
            // 
            // lblrobotconnstatus
            // 
            this.lblrobotconnstatus.BackColor = System.Drawing.Color.Maroon;
            this.lblrobotconnstatus.Location = new System.Drawing.Point(418, 28);
            this.lblrobotconnstatus.Name = "lblrobotconnstatus";
            this.lblrobotconnstatus.Size = new System.Drawing.Size(26, 26);
            this.lblrobotconnstatus.TabIndex = 171;
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnStatus.Location = new System.Drawing.Point(318, 27);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(77, 28);
            this.lblConnStatus.TabIndex = 165;
            this.lblConnStatus.Text = "Connection\r\n Status";
            this.lblConnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnconnect
            // 
            this.btnconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnconnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconnect.ForeColor = System.Drawing.Color.White;
            this.btnconnect.Location = new System.Drawing.Point(45, 501);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(110, 35);
            this.btnconnect.TabIndex = 166;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = false;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // txtsendrobotcommand
            // 
            this.txtsendrobotcommand.AccessibleName = "";
            this.txtsendrobotcommand.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsendrobotcommand.Location = new System.Drawing.Point(26, 103);
            this.txtsendrobotcommand.Name = "txtsendrobotcommand";
            this.txtsendrobotcommand.Size = new System.Drawing.Size(428, 168);
            this.txtsendrobotcommand.TabIndex = 169;
            this.txtsendrobotcommand.Text = "";
            // 
            // txtreceivecommnd
            // 
            this.txtreceivecommnd.AccessibleName = "";
            this.txtreceivecommnd.BackColor = System.Drawing.Color.White;
            this.txtreceivecommnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtreceivecommnd.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtreceivecommnd.Enabled = false;
            this.txtreceivecommnd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreceivecommnd.Location = new System.Drawing.Point(26, 318);
            this.txtreceivecommnd.Name = "txtreceivecommnd";
            this.txtreceivecommnd.ReadOnly = true;
            this.txtreceivecommnd.Size = new System.Drawing.Size(427, 167);
            this.txtreceivecommnd.TabIndex = 170;
            this.txtreceivecommnd.TabStop = false;
            this.txtreceivecommnd.Text = "";
            // 
            // label374
            // 
            this.label374.AutoSize = true;
            this.label374.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label374.Location = new System.Drawing.Point(23, 74);
            this.label374.Name = "label374";
            this.label374.Size = new System.Drawing.Size(43, 17);
            this.label374.TabIndex = 167;
            this.label374.Text = "Send";
            // 
            // btnRBTtrigger
            // 
            this.btnRBTtrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnRBTtrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRBTtrigger.ForeColor = System.Drawing.Color.White;
            this.btnRBTtrigger.Location = new System.Drawing.Point(314, 501);
            this.btnRBTtrigger.Name = "btnRBTtrigger";
            this.btnRBTtrigger.Size = new System.Drawing.Size(110, 35);
            this.btnRBTtrigger.TabIndex = 164;
            this.btnRBTtrigger.Text = "Trigger";
            this.btnRBTtrigger.UseVisualStyleBackColor = false;
            this.btnRBTtrigger.Click += new System.EventHandler(this.btnRBTtrigger_Click);
            // 
            // label376
            // 
            this.label376.AutoSize = true;
            this.label376.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label376.Location = new System.Drawing.Point(23, 288);
            this.label376.Name = "label376";
            this.label376.Size = new System.Drawing.Size(69, 17);
            this.label376.TabIndex = 168;
            this.label376.Text = "Received";
            // 
            // tabPageCamera
            // 
            this.tabPageCamera.Controls.Add(this.grpCCDConn);
            this.tabPageCamera.Location = new System.Drawing.Point(4, 27);
            this.tabPageCamera.Name = "tabPageCamera";
            this.tabPageCamera.Size = new System.Drawing.Size(1010, 583);
            this.tabPageCamera.TabIndex = 9;
            this.tabPageCamera.Text = "CAMERA";
            this.tabPageCamera.UseVisualStyleBackColor = true;
            // 
            // grpCCDConn
            // 
            this.grpCCDConn.Controls.Add(this.btnCamDisConnect);
            this.grpCCDConn.Controls.Add(this.lblSelectCCD);
            this.grpCCDConn.Controls.Add(this.cmbCCD);
            this.grpCCDConn.Controls.Add(this.lblCCDConnStatus);
            this.grpCCDConn.Controls.Add(this.btnCCDConnect);
            this.grpCCDConn.Controls.Add(this.txtSendCmd);
            this.grpCCDConn.Controls.Add(this.txtRecivdCmd);
            this.grpCCDConn.Controls.Add(this.label372);
            this.grpCCDConn.Controls.Add(this.btnCCDTrigger);
            this.grpCCDConn.Controls.Add(this.lblCCDConn);
            this.grpCCDConn.Controls.Add(this.label378);
            this.grpCCDConn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCCDConn.Location = new System.Drawing.Point(212, 133);
            this.grpCCDConn.Name = "grpCCDConn";
            this.grpCCDConn.Size = new System.Drawing.Size(586, 317);
            this.grpCCDConn.TabIndex = 171;
            this.grpCCDConn.TabStop = false;
            this.grpCCDConn.Text = "CCD";
            // 
            // btnCamDisConnect
            // 
            this.btnCamDisConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCamDisConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamDisConnect.ForeColor = System.Drawing.Color.White;
            this.btnCamDisConnect.Location = new System.Drawing.Point(367, 250);
            this.btnCamDisConnect.Name = "btnCamDisConnect";
            this.btnCamDisConnect.Size = new System.Drawing.Size(110, 35);
            this.btnCamDisConnect.TabIndex = 177;
            this.btnCamDisConnect.Text = "Disconnect";
            this.btnCamDisConnect.UseVisualStyleBackColor = false;
            this.btnCamDisConnect.Click += new System.EventHandler(this.btnCamDisConnect_Click);
            // 
            // lblSelectCCD
            // 
            this.lblSelectCCD.AutoSize = true;
            this.lblSelectCCD.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCCD.Location = new System.Drawing.Point(15, 30);
            this.lblSelectCCD.Name = "lblSelectCCD";
            this.lblSelectCCD.Size = new System.Drawing.Size(95, 16);
            this.lblSelectCCD.TabIndex = 159;
            this.lblSelectCCD.Text = "Select CCD :";
            // 
            // cmbCCD
            // 
            this.cmbCCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCCD.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCCD.FormattingEnabled = true;
            this.cmbCCD.Location = new System.Drawing.Point(116, 28);
            this.cmbCCD.Name = "cmbCCD";
            this.cmbCCD.Size = new System.Drawing.Size(136, 22);
            this.cmbCCD.TabIndex = 158;
            this.cmbCCD.SelectedIndexChanged += new System.EventHandler(this.cmbCCD_SelectedIndexChanged);
            // 
            // lblCCDConnStatus
            // 
            this.lblCCDConnStatus.BackColor = System.Drawing.Color.Maroon;
            this.lblCCDConnStatus.Location = new System.Drawing.Point(540, 30);
            this.lblCCDConnStatus.Name = "lblCCDConnStatus";
            this.lblCCDConnStatus.Size = new System.Drawing.Size(26, 26);
            this.lblCCDConnStatus.TabIndex = 157;
            // 
            // btnCCDConnect
            // 
            this.btnCCDConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCCDConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCDConnect.ForeColor = System.Drawing.Color.White;
            this.btnCCDConnect.Location = new System.Drawing.Point(99, 250);
            this.btnCCDConnect.Name = "btnCCDConnect";
            this.btnCCDConnect.Size = new System.Drawing.Size(110, 35);
            this.btnCCDConnect.TabIndex = 100;
            this.btnCCDConnect.Text = "Connect";
            this.btnCCDConnect.UseVisualStyleBackColor = false;
            this.btnCCDConnect.Click += new System.EventHandler(this.btnCCDConnect_Click);
            // 
            // txtSendCmd
            // 
            this.txtSendCmd.AccessibleName = "";
            this.txtSendCmd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendCmd.Location = new System.Drawing.Point(18, 98);
            this.txtSendCmd.Name = "txtSendCmd";
            this.txtSendCmd.Size = new System.Drawing.Size(259, 122);
            this.txtSendCmd.TabIndex = 154;
            this.txtSendCmd.Text = "";
            // 
            // txtRecivdCmd
            // 
            this.txtRecivdCmd.AccessibleName = "";
            this.txtRecivdCmd.BackColor = System.Drawing.Color.White;
            this.txtRecivdCmd.Enabled = false;
            this.txtRecivdCmd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecivdCmd.Location = new System.Drawing.Point(317, 98);
            this.txtRecivdCmd.Name = "txtRecivdCmd";
            this.txtRecivdCmd.ReadOnly = true;
            this.txtRecivdCmd.Size = new System.Drawing.Size(249, 122);
            this.txtRecivdCmd.TabIndex = 154;
            this.txtRecivdCmd.Text = "";
            // 
            // label372
            // 
            this.label372.AutoSize = true;
            this.label372.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label372.Location = new System.Drawing.Point(113, 81);
            this.label372.Name = "label372";
            this.label372.Size = new System.Drawing.Size(38, 14);
            this.label372.TabIndex = 152;
            this.label372.Text = "Send";
            // 
            // btnCCDTrigger
            // 
            this.btnCCDTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCCDTrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCDTrigger.ForeColor = System.Drawing.Color.White;
            this.btnCCDTrigger.Location = new System.Drawing.Point(231, 250);
            this.btnCCDTrigger.Name = "btnCCDTrigger";
            this.btnCCDTrigger.Size = new System.Drawing.Size(110, 35);
            this.btnCCDTrigger.TabIndex = 100;
            this.btnCCDTrigger.Text = "Trigger";
            this.btnCCDTrigger.UseVisualStyleBackColor = false;
            this.btnCCDTrigger.Click += new System.EventHandler(this.btnCCDTrigger_Click);
            // 
            // lblCCDConn
            // 
            this.lblCCDConn.AutoSize = true;
            this.lblCCDConn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCDConn.Location = new System.Drawing.Point(457, 26);
            this.lblCCDConn.Name = "lblCCDConn";
            this.lblCCDConn.Size = new System.Drawing.Size(77, 28);
            this.lblCCDConn.TabIndex = 152;
            this.lblCCDConn.Text = "Connection\r\nStatus";
            this.lblCCDConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label378
            // 
            this.label378.AutoSize = true;
            this.label378.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label378.Location = new System.Drawing.Point(401, 81);
            this.label378.Name = "label378";
            this.label378.Size = new System.Drawing.Size(61, 14);
            this.label378.TabIndex = 152;
            this.label378.Text = "Received";
            // 
            // tabPageLightControl
            // 
            this.tabPageLightControl.Controls.Add(this.groupBox14);
            this.tabPageLightControl.Location = new System.Drawing.Point(4, 27);
            this.tabPageLightControl.Name = "tabPageLightControl";
            this.tabPageLightControl.Size = new System.Drawing.Size(1010, 583);
            this.tabPageLightControl.TabIndex = 10;
            this.tabPageLightControl.Text = "LIGHT CONTROL";
            this.tabPageLightControl.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label11);
            this.groupBox14.Controls.Add(this.cmbCOMPort);
            this.groupBox14.Controls.Add(this.btnOPTDisconnect);
            this.groupBox14.Controls.Add(this.cmbOPTSend);
            this.groupBox14.Controls.Add(this.lblOPTConStatus);
            this.groupBox14.Controls.Add(this.btnOPTConnect);
            this.groupBox14.Controls.Add(this.rtReceiveOPT);
            this.groupBox14.Controls.Add(this.label16);
            this.groupBox14.Controls.Add(this.btnOPTTrigger);
            this.groupBox14.Controls.Add(this.label17);
            this.groupBox14.Controls.Add(this.label18);
            this.groupBox14.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.Location = new System.Drawing.Point(200, 137);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(610, 251);
            this.groupBox14.TabIndex = 173;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "OPT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(27, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 16);
            this.label11.TabIndex = 180;
            this.label11.Text = "Select COM Port :";
            // 
            // cmbCOMPort
            // 
            this.cmbCOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOMPort.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCOMPort.FormattingEnabled = true;
            this.cmbCOMPort.Location = new System.Drawing.Point(164, 45);
            this.cmbCOMPort.Name = "cmbCOMPort";
            this.cmbCOMPort.Size = new System.Drawing.Size(132, 22);
            this.cmbCOMPort.TabIndex = 179;
            // 
            // btnOPTDisconnect
            // 
            this.btnOPTDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnOPTDisconnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPTDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnOPTDisconnect.Location = new System.Drawing.Point(376, 192);
            this.btnOPTDisconnect.Name = "btnOPTDisconnect";
            this.btnOPTDisconnect.Size = new System.Drawing.Size(110, 35);
            this.btnOPTDisconnect.TabIndex = 178;
            this.btnOPTDisconnect.Text = "Disconnect";
            this.btnOPTDisconnect.UseVisualStyleBackColor = false;
            this.btnOPTDisconnect.Click += new System.EventHandler(this.btnOPTDisconnect_Click);
            // 
            // cmbOPTSend
            // 
            this.cmbOPTSend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOPTSend.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOPTSend.FormattingEnabled = true;
            this.cmbOPTSend.Items.AddRange(new object[] {
            "WHITE",
            "RED",
            "BLACK",
            "BLUE"});
            this.cmbOPTSend.Location = new System.Drawing.Point(124, 102);
            this.cmbOPTSend.Name = "cmbOPTSend";
            this.cmbOPTSend.Size = new System.Drawing.Size(132, 22);
            this.cmbOPTSend.TabIndex = 162;
            this.cmbOPTSend.SelectedIndexChanged += new System.EventHandler(this.cmbOPTSend_SelectedIndexChanged);
            // 
            // lblOPTConStatus
            // 
            this.lblOPTConStatus.BackColor = System.Drawing.Color.Maroon;
            this.lblOPTConStatus.Location = new System.Drawing.Point(559, 26);
            this.lblOPTConStatus.Name = "lblOPTConStatus";
            this.lblOPTConStatus.Size = new System.Drawing.Size(26, 26);
            this.lblOPTConStatus.TabIndex = 157;
            // 
            // btnOPTConnect
            // 
            this.btnOPTConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnOPTConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPTConnect.ForeColor = System.Drawing.Color.White;
            this.btnOPTConnect.Location = new System.Drawing.Point(109, 193);
            this.btnOPTConnect.Name = "btnOPTConnect";
            this.btnOPTConnect.Size = new System.Drawing.Size(99, 35);
            this.btnOPTConnect.TabIndex = 100;
            this.btnOPTConnect.Text = "Connect";
            this.btnOPTConnect.UseVisualStyleBackColor = false;
            this.btnOPTConnect.Click += new System.EventHandler(this.btnOPTConnect_Click);
            // 
            // rtReceiveOPT
            // 
            this.rtReceiveOPT.AccessibleName = "";
            this.rtReceiveOPT.BackColor = System.Drawing.Color.White;
            this.rtReceiveOPT.Enabled = false;
            this.rtReceiveOPT.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtReceiveOPT.Location = new System.Drawing.Point(417, 98);
            this.rtReceiveOPT.Name = "rtReceiveOPT";
            this.rtReceiveOPT.ReadOnly = true;
            this.rtReceiveOPT.Size = new System.Drawing.Size(175, 33);
            this.rtReceiveOPT.TabIndex = 154;
            this.rtReceiveOPT.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(35, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 14);
            this.label16.TabIndex = 152;
            this.label16.Text = "Send";
            // 
            // btnOPTTrigger
            // 
            this.btnOPTTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnOPTTrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPTTrigger.ForeColor = System.Drawing.Color.White;
            this.btnOPTTrigger.Location = new System.Drawing.Point(242, 192);
            this.btnOPTTrigger.Name = "btnOPTTrigger";
            this.btnOPTTrigger.Size = new System.Drawing.Size(99, 35);
            this.btnOPTTrigger.TabIndex = 100;
            this.btnOPTTrigger.Text = "Trigger";
            this.btnOPTTrigger.UseVisualStyleBackColor = false;
            this.btnOPTTrigger.Click += new System.EventHandler(this.btnOPTTrigger_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(484, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 26);
            this.label17.TabIndex = 152;
            this.label17.Text = "Connection\r\nStatus";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(342, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 14);
            this.label18.TabIndex = 152;
            this.label18.Text = "Received";
            // 
            // tabPageScanner
            // 
            this.tabPageScanner.Controls.Add(this.grpScanner);
            this.tabPageScanner.Location = new System.Drawing.Point(4, 27);
            this.tabPageScanner.Name = "tabPageScanner";
            this.tabPageScanner.Size = new System.Drawing.Size(1010, 583);
            this.tabPageScanner.TabIndex = 11;
            this.tabPageScanner.Text = "SCANNER";
            this.tabPageScanner.UseVisualStyleBackColor = true;
            // 
            // grpScanner
            // 
            this.grpScanner.Controls.Add(this.btnScnrDisconnect);
            this.grpScanner.Controls.Add(this.lblScannerSel);
            this.grpScanner.Controls.Add(this.cmbScanner);
            this.grpScanner.Controls.Add(this.lblScanrConStatus);
            this.grpScanner.Controls.Add(this.btnScannerConnect);
            this.grpScanner.Controls.Add(this.txtScannerSend);
            this.grpScanner.Controls.Add(this.txtScannerRecieve);
            this.grpScanner.Controls.Add(this.label380);
            this.grpScanner.Controls.Add(this.btnScannerTrigger);
            this.grpScanner.Controls.Add(this.lblScannerConn);
            this.grpScanner.Controls.Add(this.label382);
            this.grpScanner.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScanner.Location = new System.Drawing.Point(200, 137);
            this.grpScanner.Name = "grpScanner";
            this.grpScanner.Size = new System.Drawing.Size(610, 308);
            this.grpScanner.TabIndex = 172;
            this.grpScanner.TabStop = false;
            this.grpScanner.Text = "Scanner";
            // 
            // btnScnrDisconnect
            // 
            this.btnScnrDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScnrDisconnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScnrDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnScnrDisconnect.Location = new System.Drawing.Point(376, 248);
            this.btnScnrDisconnect.Name = "btnScnrDisconnect";
            this.btnScnrDisconnect.Size = new System.Drawing.Size(110, 35);
            this.btnScnrDisconnect.TabIndex = 178;
            this.btnScnrDisconnect.Text = "Disconnect";
            this.btnScnrDisconnect.UseVisualStyleBackColor = false;
            this.btnScnrDisconnect.Click += new System.EventHandler(this.btnScnrDisconnect_Click);
            // 
            // lblScannerSel
            // 
            this.lblScannerSel.AutoSize = true;
            this.lblScannerSel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerSel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScannerSel.Location = new System.Drawing.Point(28, 32);
            this.lblScannerSel.Name = "lblScannerSel";
            this.lblScannerSel.Size = new System.Drawing.Size(124, 16);
            this.lblScannerSel.TabIndex = 163;
            this.lblScannerSel.Text = "Select Scanner :";
            // 
            // cmbScanner
            // 
            this.cmbScanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanner.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbScanner.FormattingEnabled = true;
            this.cmbScanner.Location = new System.Drawing.Point(151, 30);
            this.cmbScanner.Name = "cmbScanner";
            this.cmbScanner.Size = new System.Drawing.Size(165, 22);
            this.cmbScanner.TabIndex = 162;
            // 
            // lblScanrConStatus
            // 
            this.lblScanrConStatus.BackColor = System.Drawing.Color.Maroon;
            this.lblScanrConStatus.Location = new System.Drawing.Point(559, 26);
            this.lblScanrConStatus.Name = "lblScanrConStatus";
            this.lblScanrConStatus.Size = new System.Drawing.Size(26, 26);
            this.lblScanrConStatus.TabIndex = 157;
            // 
            // btnScannerConnect
            // 
            this.btnScannerConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScannerConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScannerConnect.ForeColor = System.Drawing.Color.White;
            this.btnScannerConnect.Location = new System.Drawing.Point(109, 249);
            this.btnScannerConnect.Name = "btnScannerConnect";
            this.btnScannerConnect.Size = new System.Drawing.Size(99, 35);
            this.btnScannerConnect.TabIndex = 100;
            this.btnScannerConnect.Text = "Connect";
            this.btnScannerConnect.UseVisualStyleBackColor = false;
            this.btnScannerConnect.Click += new System.EventHandler(this.btnScannerConnect_Click);
            // 
            // txtScannerSend
            // 
            this.txtScannerSend.AccessibleName = "";
            this.txtScannerSend.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannerSend.Location = new System.Drawing.Point(32, 106);
            this.txtScannerSend.Name = "txtScannerSend";
            this.txtScannerSend.Size = new System.Drawing.Size(260, 122);
            this.txtScannerSend.TabIndex = 154;
            this.txtScannerSend.Text = "";
            // 
            // txtScannerRecieve
            // 
            this.txtScannerRecieve.AccessibleName = "";
            this.txtScannerRecieve.BackColor = System.Drawing.Color.White;
            this.txtScannerRecieve.Enabled = false;
            this.txtScannerRecieve.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannerRecieve.Location = new System.Drawing.Point(317, 106);
            this.txtScannerRecieve.Name = "txtScannerRecieve";
            this.txtScannerRecieve.ReadOnly = true;
            this.txtScannerRecieve.Size = new System.Drawing.Size(260, 122);
            this.txtScannerRecieve.TabIndex = 154;
            this.txtScannerRecieve.Text = "";
            // 
            // label380
            // 
            this.label380.AutoSize = true;
            this.label380.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label380.Location = new System.Drawing.Point(117, 78);
            this.label380.Name = "label380";
            this.label380.Size = new System.Drawing.Size(38, 14);
            this.label380.TabIndex = 152;
            this.label380.Text = "Send";
            // 
            // btnScannerTrigger
            // 
            this.btnScannerTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScannerTrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScannerTrigger.ForeColor = System.Drawing.Color.White;
            this.btnScannerTrigger.Location = new System.Drawing.Point(242, 248);
            this.btnScannerTrigger.Name = "btnScannerTrigger";
            this.btnScannerTrigger.Size = new System.Drawing.Size(99, 35);
            this.btnScannerTrigger.TabIndex = 100;
            this.btnScannerTrigger.Text = "Trigger";
            this.btnScannerTrigger.UseVisualStyleBackColor = false;
            this.btnScannerTrigger.Click += new System.EventHandler(this.btnScannerTrigger_Click);
            // 
            // lblScannerConn
            // 
            this.lblScannerConn.AutoSize = true;
            this.lblScannerConn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblScannerConn.Location = new System.Drawing.Point(484, 26);
            this.lblScannerConn.Name = "lblScannerConn";
            this.lblScannerConn.Size = new System.Drawing.Size(70, 26);
            this.lblScannerConn.TabIndex = 152;
            this.lblScannerConn.Text = "Connection\r\nStatus";
            this.lblScannerConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label382
            // 
            this.label382.AutoSize = true;
            this.label382.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label382.Location = new System.Drawing.Point(398, 78);
            this.label382.Name = "label382";
            this.label382.Size = new System.Drawing.Size(61, 14);
            this.label382.TabIndex = 152;
            this.label382.Text = "Received";
            // 
            // tabPageSfcPdca
            // 
            this.tabPageSfcPdca.Controls.Add(this.groupBox7);
            this.tabPageSfcPdca.Location = new System.Drawing.Point(4, 27);
            this.tabPageSfcPdca.Name = "tabPageSfcPdca";
            this.tabPageSfcPdca.Size = new System.Drawing.Size(1010, 583);
            this.tabPageSfcPdca.TabIndex = 12;
            this.tabPageSfcPdca.Text = "SFC & PDCA";
            this.tabPageSfcPdca.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.btnPDCATrigger);
            this.groupBox7.Controls.Add(this.rtSendPDCA);
            this.groupBox7.Controls.Add(this.rtReceivePDCA);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.btnSFCDisConnect);
            this.groupBox7.Controls.Add(this.lblSFCConStatus);
            this.groupBox7.Controls.Add(this.btnSFCConnect);
            this.groupBox7.Controls.Add(this.rtSendSFC);
            this.groupBox7.Controls.Add(this.rtReceiveSFC);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.btnSFCTrigger);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(130, 60);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(750, 462);
            this.groupBox7.TabIndex = 174;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "SFC_PDCA";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(405, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 14);
            this.label23.TabIndex = 186;
            this.label23.Text = "PDCA";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(29, 50);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 14);
            this.label21.TabIndex = 185;
            this.label21.Text = "SFC";
            // 
            // btnPDCATrigger
            // 
            this.btnPDCATrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnPDCATrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDCATrigger.ForeColor = System.Drawing.Color.White;
            this.btnPDCATrigger.Location = new System.Drawing.Point(512, 343);
            this.btnPDCATrigger.Name = "btnPDCATrigger";
            this.btnPDCATrigger.Size = new System.Drawing.Size(99, 35);
            this.btnPDCATrigger.TabIndex = 184;
            this.btnPDCATrigger.Text = "Trigger";
            this.btnPDCATrigger.UseVisualStyleBackColor = false;
            this.btnPDCATrigger.Click += new System.EventHandler(this.btnPDCATrigger_Click);
            // 
            // rtSendPDCA
            // 
            this.rtSendPDCA.AccessibleName = "";
            this.rtSendPDCA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtSendPDCA.Location = new System.Drawing.Point(399, 97);
            this.rtSendPDCA.Name = "rtSendPDCA";
            this.rtSendPDCA.Size = new System.Drawing.Size(316, 88);
            this.rtSendPDCA.TabIndex = 182;
            this.rtSendPDCA.Text = "";
            // 
            // rtReceivePDCA
            // 
            this.rtReceivePDCA.AccessibleName = "";
            this.rtReceivePDCA.BackColor = System.Drawing.Color.White;
            this.rtReceivePDCA.Enabled = false;
            this.rtReceivePDCA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtReceivePDCA.Location = new System.Drawing.Point(399, 227);
            this.rtReceivePDCA.Name = "rtReceivePDCA";
            this.rtReceivePDCA.ReadOnly = true;
            this.rtReceivePDCA.Size = new System.Drawing.Size(316, 93);
            this.rtReceivePDCA.TabIndex = 183;
            this.rtReceivePDCA.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(396, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 14);
            this.label19.TabIndex = 180;
            this.label19.Text = "Send";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(396, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 14);
            this.label20.TabIndex = 181;
            this.label20.Text = "Received";
            // 
            // btnSFCDisConnect
            // 
            this.btnSFCDisConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSFCDisConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSFCDisConnect.ForeColor = System.Drawing.Color.White;
            this.btnSFCDisConnect.Location = new System.Drawing.Point(399, 420);
            this.btnSFCDisConnect.Name = "btnSFCDisConnect";
            this.btnSFCDisConnect.Size = new System.Drawing.Size(110, 35);
            this.btnSFCDisConnect.TabIndex = 179;
            this.btnSFCDisConnect.Text = "Disconnect";
            this.btnSFCDisConnect.UseVisualStyleBackColor = false;
            this.btnSFCDisConnect.Click += new System.EventHandler(this.btnSFCDisConnect_Click);
            // 
            // lblSFCConStatus
            // 
            this.lblSFCConStatus.BackColor = System.Drawing.Color.Maroon;
            this.lblSFCConStatus.Location = new System.Drawing.Point(662, 26);
            this.lblSFCConStatus.Name = "lblSFCConStatus";
            this.lblSFCConStatus.Size = new System.Drawing.Size(26, 26);
            this.lblSFCConStatus.TabIndex = 157;
            // 
            // btnSFCConnect
            // 
            this.btnSFCConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSFCConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSFCConnect.ForeColor = System.Drawing.Color.White;
            this.btnSFCConnect.Location = new System.Drawing.Point(266, 420);
            this.btnSFCConnect.Name = "btnSFCConnect";
            this.btnSFCConnect.Size = new System.Drawing.Size(99, 35);
            this.btnSFCConnect.TabIndex = 100;
            this.btnSFCConnect.Text = "Connect";
            this.btnSFCConnect.UseVisualStyleBackColor = false;
            this.btnSFCConnect.Click += new System.EventHandler(this.btnSFCConnect_Click);
            // 
            // rtSendSFC
            // 
            this.rtSendSFC.AccessibleName = "";
            this.rtSendSFC.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtSendSFC.Location = new System.Drawing.Point(32, 97);
            this.rtSendSFC.Name = "rtSendSFC";
            this.rtSendSFC.Size = new System.Drawing.Size(316, 88);
            this.rtSendSFC.TabIndex = 154;
            this.rtSendSFC.Text = "";
            this.rtSendSFC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtSendSFC_KeyDown);
            // 
            // rtReceiveSFC
            // 
            this.rtReceiveSFC.AccessibleName = "";
            this.rtReceiveSFC.BackColor = System.Drawing.Color.White;
            this.rtReceiveSFC.Enabled = false;
            this.rtReceiveSFC.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtReceiveSFC.Location = new System.Drawing.Point(32, 227);
            this.rtReceiveSFC.Name = "rtReceiveSFC";
            this.rtReceiveSFC.ReadOnly = true;
            this.rtReceiveSFC.Size = new System.Drawing.Size(316, 93);
            this.rtReceiveSFC.TabIndex = 154;
            this.rtReceiveSFC.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 14);
            this.label13.TabIndex = 152;
            this.label13.Text = "Send";
            // 
            // btnSFCTrigger
            // 
            this.btnSFCTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSFCTrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSFCTrigger.ForeColor = System.Drawing.Color.White;
            this.btnSFCTrigger.Location = new System.Drawing.Point(121, 343);
            this.btnSFCTrigger.Name = "btnSFCTrigger";
            this.btnSFCTrigger.Size = new System.Drawing.Size(99, 35);
            this.btnSFCTrigger.TabIndex = 100;
            this.btnSFCTrigger.Text = "Trigger";
            this.btnSFCTrigger.UseVisualStyleBackColor = false;
            this.btnSFCTrigger.Click += new System.EventHandler(this.btnSFCTrigger_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(583, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 26);
            this.label14.TabIndex = 152;
            this.label14.Text = "Connection\r\nStatus";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(29, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 14);
            this.label15.TabIndex = 152;
            this.label15.Text = "Received";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbConveyorStepperCombo
            // 
            this.cmbConveyorStepperCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConveyorStepperCombo.FormattingEnabled = true;
            this.cmbConveyorStepperCombo.Location = new System.Drawing.Point(396, 17);
            this.cmbConveyorStepperCombo.Name = "cmbConveyorStepperCombo";
            this.cmbConveyorStepperCombo.Size = new System.Drawing.Size(219, 26);
            this.cmbConveyorStepperCombo.TabIndex = 98;
            this.cmbConveyorStepperCombo.SelectedIndexChanged += new System.EventHandler(this.cmbConveyorStepperCombo_SelectedIndexChanged);
            // 
            // ManualScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 620);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManualScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ManualScreen1";
            this.Load += new System.EventHandler(this.ManualScreen_Load);
            this.tabControl1.ResumeLayout(false);
            this.Conveyor.ResumeLayout(false);
            this.Conveyor.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.PickGantry.ResumeLayout(false);
            this.PickGantry.PerformLayout();
            this.ScrewGantry.ResumeLayout(false);
            this.ScrewGantry.PerformLayout();
            this.Screw_Gantry.ResumeLayout(false);
            this.AxisY1.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox44.ResumeLayout(false);
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.groupBox46.ResumeLayout(false);
            this.groupBox46.PerformLayout();
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.groupBox48.ResumeLayout(false);
            this.groupBox48.PerformLayout();
            this.groupBox49.ResumeLayout(false);
            this.groupBox49.PerformLayout();
            this.groupBox50.ResumeLayout(false);
            this.groupBox50.PerformLayout();
            this.AxisY2.ResumeLayout(false);
            this.groupBox94.ResumeLayout(false);
            this.groupBox95.ResumeLayout(false);
            this.groupBox96.ResumeLayout(false);
            this.groupBox96.PerformLayout();
            this.groupBox97.ResumeLayout(false);
            this.groupBox97.PerformLayout();
            this.groupBox98.ResumeLayout(false);
            this.groupBox98.PerformLayout();
            this.groupBox99.ResumeLayout(false);
            this.groupBox99.PerformLayout();
            this.groupBox100.ResumeLayout(false);
            this.groupBox100.PerformLayout();
            this.groupBox101.ResumeLayout(false);
            this.groupBox101.PerformLayout();
            this.AxisX1.ResumeLayout(false);
            this.groupBox51.ResumeLayout(false);
            this.groupBox52.ResumeLayout(false);
            this.groupBox61.ResumeLayout(false);
            this.groupBox61.PerformLayout();
            this.groupBox62.ResumeLayout(false);
            this.groupBox62.PerformLayout();
            this.groupBox63.ResumeLayout(false);
            this.groupBox63.PerformLayout();
            this.groupBox64.ResumeLayout(false);
            this.groupBox64.PerformLayout();
            this.groupBox65.ResumeLayout(false);
            this.groupBox65.PerformLayout();
            this.groupBox66.ResumeLayout(false);
            this.groupBox66.PerformLayout();
            this.AxisX2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox79.ResumeLayout(false);
            this.groupBox79.PerformLayout();
            this.groupBox80.ResumeLayout(false);
            this.groupBox80.PerformLayout();
            this.AxisZ1.ResumeLayout(false);
            this.groupBox67.ResumeLayout(false);
            this.groupBox68.ResumeLayout(false);
            this.groupBox69.ResumeLayout(false);
            this.groupBox69.PerformLayout();
            this.groupBox70.ResumeLayout(false);
            this.groupBox70.PerformLayout();
            this.groupBox71.ResumeLayout(false);
            this.groupBox71.PerformLayout();
            this.groupBox72.ResumeLayout(false);
            this.groupBox72.PerformLayout();
            this.groupBox73.ResumeLayout(false);
            this.groupBox73.PerformLayout();
            this.groupBox74.ResumeLayout(false);
            this.groupBox74.PerformLayout();
            this.AxisZ2.ResumeLayout(false);
            this.groupBox75.ResumeLayout(false);
            this.groupBox76.ResumeLayout(false);
            this.groupBox77.ResumeLayout(false);
            this.groupBox77.PerformLayout();
            this.groupBox78.ResumeLayout(false);
            this.groupBox78.PerformLayout();
            this.groupBox83.ResumeLayout(false);
            this.groupBox83.PerformLayout();
            this.groupBox86.ResumeLayout(false);
            this.groupBox86.PerformLayout();
            this.groupBox88.ResumeLayout(false);
            this.groupBox88.PerformLayout();
            this.groupBox93.ResumeLayout(false);
            this.groupBox93.PerformLayout();
            this.Feeder.ResumeLayout(false);
            this.Feeder.PerformLayout();
            this.tabFeeder.ResumeLayout(false);
            this.Loader.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.Unloader.ResumeLayout(false);
            this.groupBox30.ResumeLayout(false);
            this.groupBox53.ResumeLayout(false);
            this.groupBox54.ResumeLayout(false);
            this.groupBox55.ResumeLayout(false);
            this.groupBox55.PerformLayout();
            this.groupBox56.ResumeLayout(false);
            this.groupBox56.PerformLayout();
            this.groupBox57.ResumeLayout(false);
            this.groupBox57.PerformLayout();
            this.groupBox58.ResumeLayout(false);
            this.groupBox58.PerformLayout();
            this.groupBox59.ResumeLayout(false);
            this.groupBox59.PerformLayout();
            this.groupBox60.ResumeLayout(false);
            this.groupBox60.PerformLayout();
            this.Shuttle.ResumeLayout(false);
            this.Shuttle.PerformLayout();
            this.InternalShuttle.ResumeLayout(false);
            this.Shuttle1.ResumeLayout(false);
            this.groupBox82.ResumeLayout(false);
            this.groupBox85.ResumeLayout(false);
            this.groupBox87.ResumeLayout(false);
            this.groupBox87.PerformLayout();
            this.groupBox89.ResumeLayout(false);
            this.groupBox89.PerformLayout();
            this.groupBox90.ResumeLayout(false);
            this.groupBox90.PerformLayout();
            this.groupBox91.ResumeLayout(false);
            this.groupBox91.PerformLayout();
            this.groupBox92.ResumeLayout(false);
            this.groupBox92.PerformLayout();
            this.groupBox102.ResumeLayout(false);
            this.groupBox102.PerformLayout();
            this.Shuttle2.ResumeLayout(false);
            this.groupBox103.ResumeLayout(false);
            this.groupBox112.ResumeLayout(false);
            this.groupBox106.ResumeLayout(false);
            this.groupBox106.PerformLayout();
            this.groupBox107.ResumeLayout(false);
            this.groupBox107.PerformLayout();
            this.groupBox108.ResumeLayout(false);
            this.groupBox108.PerformLayout();
            this.groupBox109.ResumeLayout(false);
            this.groupBox109.PerformLayout();
            this.groupBox110.ResumeLayout(false);
            this.groupBox110.PerformLayout();
            this.groupBox111.ResumeLayout(false);
            this.groupBox111.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageAxis.ResumeLayout(false);
            this.ServosettingsPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.grbPTP.ResumeLayout(false);
            this.grbPTP.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.AxisSelectPanel.ResumeLayout(false);
            this.AxisSelectPanel.PerformLayout();
            this.tabPageStepper.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.grp_IO_Conv.ResumeLayout(false);
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            this.groupBox42.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.grp_IO_Conv_Stepper_2.ResumeLayout(false);
            this.grp_IO_Conv_Stepper_1.ResumeLayout(false);
            this.grp_IO_Conv_Stepper_1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageCylinder.ResumeLayout(false);
            this.tabPageVacuum.ResumeLayout(false);
            this.tabPageRobot.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpRoboConn.ResumeLayout(false);
            this.grpRoboConn.PerformLayout();
            this.tabPageCamera.ResumeLayout(false);
            this.grpCCDConn.ResumeLayout(false);
            this.grpCCDConn.PerformLayout();
            this.tabPageLightControl.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.tabPageScanner.ResumeLayout(false);
            this.grpScanner.ResumeLayout(false);
            this.grpScanner.PerformLayout();
            this.tabPageSfcPdca.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage Conveyor;
        private Button button25;
        private Button button23;
        private Label label1;
        private GroupBox groupBox32;
        private ComboBox comboBox11;
        private Label label162;
        private Label label163;
        private Label label164;
        private Button button33;
        private Button button34;
        private GroupBox groupBox37;
        private ComboBox comboBox9;
        private Label label222;
        private Label label221;
        private Label label220;
        private Button button49;
        private Button Streamline1_Start;
        private TabPage PickGantry;
        private GroupBox AxisGroup;
        private Label AxisLabel;
        private ComboBox AxisCombo;
        private Button button17;
        private Button DryCycle;
        private Label label6;
        private TabPage ScrewGantry;
        private Button button24;
        private Button button19;
        private Button button22;
        private Button button21;
        private Label label8;
        private TabControl Screw_Gantry;
        private TabPage AxisY1;
        private GroupBox groupBox22;
        private GroupBox groupBox44;
        private Button Btn_ScrewServo_Enable_X1;
        private Button btnScrewServoX1ClearErr;
        private Button Btn_ScrewServo_disable_X1;
        private GroupBox groupBox45;
        private Label label24;
        private Label lbl_X1ScrewServo_ActualPosition;
        private Label label72;
        private Label label90;
        private Label label110;
        private Label Targetposition_Screw_X1;
        private GroupBox groupBox46;
        private Button button4;
        private Button button5;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private Label label144;
        private Label label145;
        private TextBox textBox18;
        private Label label152;
        private TextBox textBox21;
        private Label label154;
        private Label label155;
        private Label label160;
        private Label label161;
        private Label label165;
        private Label label178;
        private Label label183;
        private GroupBox groupBox47;
        private ComboBox comboBox1;
        private Label label184;
        private TextBox textBox23;
        private Label label185;
        private Label label186;
        private Button button6;
        private Button btnScrewJogAdd_X1;
        private Label label187;
        private GroupBox groupBox48;
        private Button btn_X1stop_home;
        private Label label194;
        private Button btnScrewHome_X1;
        private TextBox textBox24;
        private Label label195;
        private GroupBox groupBox49;
        private Button btn_x1ScrewMove_stop;
        private Button btnScrewSVMove_X1;
        private Label label196;
        private Label label197;
        private TextBox lbl_X1ScrewSV_Speed;
        private Label label198;
        private TextBox lbl_X1ScrewSV_TargetPosition;
        private Label label199;
        private GroupBox groupBox50;
        private Label lblScrewServoX1disable;
        private Label label201;
        private Label lblScrewServoX1Error;
        private Label label203;
        private Label lblScrewServoX1Positive_limit;
        private Label label205;
        private Label lblScrewServoX1Home;
        private Label lblScrewServoX1Running;
        private Label lblScrewServoX1Ready;
        private Label lblScrewServoX1Negative_limit;
        private Label lblScrewServoX1Enable;
        private Label label211;
        private Label label212;
        private Label label213;
        private Label label214;
        private Label label215;
        private TabPage AxisY2;
        private GroupBox groupBox94;
        private GroupBox groupBox95;
        private Button Btn_ScrewServo_Enable_X2;
        private Button btnScrewServoX2ClearErr;
        private Button Btn_ScrewServo_disable_X2;
        private GroupBox groupBox96;
        private Label label396;
        private Label lbl_X2ScrewServo_ActualPosition;
        private Label label400;
        private Label label401;
        private Label label402;
        private Label Targetposition_Screw_X2;
        private GroupBox groupBox97;
        private Button button85;
        private Button button86;
        private TextBox textBox70;
        private TextBox textBox71;
        private TextBox textBox72;
        private Label label404;
        private Label label405;
        private TextBox textBox73;
        private Label label406;
        private TextBox textBox74;
        private Label label407;
        private Label label412;
        private Label label413;
        private Label label414;
        private Label label415;
        private Label label416;
        private Label label417;
        private GroupBox groupBox98;
        private ComboBox comboBox7;
        private Label label418;
        private TextBox textBox75;
        private Label label419;
        private Label label420;
        private Button button87;
        private Button button88;
        private Label label421;
        private GroupBox groupBox99;
        private Button btn_X2stop_home;
        private Label label422;
        private Button btnScrewHome_X2;
        private TextBox textBox76;
        private Label label488;
        private GroupBox groupBox100;
        private Button btn_x2ScrewMove_stop;
        private Button btnScrewSVMove_X2;
        private Label label489;
        private Label label490;
        private TextBox lbl_X2ScrewSV_Speed;
        private Label label491;
        private TextBox txt_targetposition_ScrewX2;
        private Label label492;
        private GroupBox groupBox101;
        private Label lblScrewServoX2disable;
        private Label label494;
        private Label lblScrewServoX2Error;
        private Label label496;
        private Label lblScrewServoX2Positive_limit;
        private Label label498;
        private Label lblScrewServoX2Home;
        private Label lblScrewServoX2Running;
        private Label lblScrewServoX2Ready;
        private Label lblScrewServoX2Negative_limit;
        private Label lblScrewServoX2Enable;
        private Label label504;
        private Label label505;
        private Label label506;
        private Label label507;
        private Label label508;
        private TabPage AxisX1;
        private GroupBox groupBox51;
        private GroupBox groupBox52;
        private Button Btn_ScrewServo_Enable_Y1;
        private Button btnScrewServoY1ClearErr;
        private Button Btn_ScrewServo_disable_Y1;
        private GroupBox groupBox61;
        private Label label216;
        private Label lbl_Y1ScrewServo_ActualPosition;
        private Label label218;
        private Label label219;
        private Label label223;
        private Label lbl_Y1ScrewSV_TP;
        private GroupBox groupBox62;
        private Button button26;
        private Button button27;
        private TextBox textBox33;
        private TextBox textBox37;
        private TextBox textBox38;
        private Label label225;
        private Label label226;
        private TextBox textBox39;
        private Label label227;
        private TextBox textBox40;
        private Label label228;
        private Label label230;
        private Label label231;
        private Label label232;
        private Label label233;
        private Label label234;
        private Label label235;
        private GroupBox groupBox63;
        private ComboBox comboBox2;
        private Label label236;
        private TextBox textBox41;
        private Label label237;
        private Label label238;
        private Button button28;
        private Button button29;
        private Label label239;
        private GroupBox groupBox64;
        private Button btn_Y1stop_home;
        private Label label240;
        private Button btnScrewHome_Y1;
        private TextBox textBox42;
        private Label label241;
        private GroupBox groupBox65;
        private Button button32;
        private Button btnScrewSVMove_Y1;
        private Label label243;
        private Label label244;
        private TextBox lbl_Y1ScrewSV_Speed;
        private Label label245;
        private TextBox lbl_Y1ScrewSV_TargetPosition;
        private Label label246;
        private GroupBox groupBox66;
        private Label lblScrewServoY1disable;
        private Label label268;
        private Label lblScrewServoY1Error;
        private Label label272;
        private Label lblScrewServoY1Home;
        private Label lblScrewServoY1Running;
        private Label lblScrewServoY1Ready;
        private Label lblScrewServoY1Enable;
        private Label label285;
        private Label label286;
        private Label label288;
        private Label label289;
        private TabPage AxisX2;
        private GroupBox groupBox4;
        private GroupBox groupBox9;
        private Button button1;
        private Button button2;
        private Button button3;
        private GroupBox groupBox31;
        private Label label42;
        private Label lblActPosAX2;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label67;
        private GroupBox groupBox33;
        private Button button7;
        private Button button8;
        private TextBox textBox1;
        private TextBox textBox7;
        private TextBox textBox9;
        private Label label68;
        private Label label69;
        private TextBox textBox10;
        private Label label70;
        private TextBox textBox14;
        private Label label71;
        private Label label74;
        private Label label76;
        private Label label78;
        private Label label79;
        private Label label81;
        private Label label82;
        private GroupBox groupBox38;
        private ComboBox comboBox10;
        private Label label84;
        private TextBox textBox30;
        private Label label85;
        private Label label86;
        private Button button9;
        private Button button10;
        private Label label87;
        private GroupBox groupBox39;
        private Button button11;
        private Label label88;
        private Button button12;
        private TextBox textBox32;
        private Label label89;
        private GroupBox groupBox79;
        private Button button13;
        private Button button14;
        private Label label106;
        private Label label108;
        private TextBox txtTargSpdAX2;
        private Label label111;
        private TextBox txtTargPosAX2;
        private Label label114;
        private GroupBox groupBox80;
        private Label txtAX2Disable;
        private Label label136;
        private Label label137;
        private Label label139;
        private Label label142;
        private Label label143;
        private Label label159;
        private Label txtAX2Enable;
        private Label label179;
        private Label label182;
        private Label label202;
        private Label label204;
        private TabPage AxisZ1;
        private GroupBox groupBox67;
        private GroupBox groupBox68;
        private Button Btn_ScrewServo_Enable_Z1;
        private Button btnScrewServoZ1ClearErr;
        private Button Btn_ScrewServo_disable_Z1;
        private GroupBox groupBox69;
        private Label lbl_Z1ScrewSV_TP;
        private Label label291;
        private Label label292;
        private Label lbl_Z1ScrewServo_ActualPosition;
        private Label label294;
        private Label label295;
        private GroupBox groupBox70;
        private Button button39;
        private Button button40;
        private TextBox textBox45;
        private TextBox textBox48;
        private TextBox textBox50;
        private Label label296;
        private Label label297;
        private TextBox textBox51;
        private Label label298;
        private TextBox textBox52;
        private Label label299;
        private Label label300;
        private Label label301;
        private Label label302;
        private Label label303;
        private Label label304;
        private Label label305;
        private GroupBox groupBox71;
        private ComboBox comboBox4;
        private Label label306;
        private TextBox textBox53;
        private Label label307;
        private Label label308;
        private Button button41;
        private Button button42;
        private Label label309;
        private GroupBox groupBox72;
        private Button button43;
        private Label label310;
        private Button btnScrewHome_Z1;
        private TextBox textBox54;
        private Label label311;
        private GroupBox groupBox73;
        private Button btn_Z1ScrewMove_stop;
        private Button btnScrewSVMove_Z1;
        private Label label322;
        private Label label323;
        private TextBox lbl_Z1ScrewSV_TargetSpeed;
        private Label label324;
        private TextBox lbl_Z1ScrewSV_TargetPosition;
        private Label label325;
        private GroupBox groupBox74;
        private Label lblScrewServoZ1disable;
        private Label label327;
        private Label lblScrewServoZ1Error;
        private Label label329;
        private Label lblScrewServoZ1Positive_limit;
        private Label label331;
        private Label lblScrewServoZ1Home;
        private Label lblScrewServoZ1Running;
        private Label lblScrewServoZ1Ready;
        private Label lblScrewServoZ1Negative_limit;
        private Label lblScrewServoZ1Enable;
        private Label label337;
        private Label label338;
        private Label label339;
        private Label label340;
        private Label label341;
        private TabPage AxisZ2;
        private GroupBox groupBox75;
        private GroupBox groupBox76;
        private Button Btn_ScrewServo_Enable_Z2;
        private Button btnScrewServoZ2ClearErr;
        private Button Btn_ScrewServo_disable_Z2;
        private GroupBox groupBox77;
        private Label lbl_Z2ScrewSV_TP;
        private Label label344;
        private Label label345;
        private Label lbl_Z2Servo_ActualPosition;
        private Label label347;
        private Label label348;
        private GroupBox groupBox78;
        private Button button74;
        private Button button75;
        private TextBox textBox60;
        private TextBox textBox61;
        private TextBox textBox62;
        private Label label349;
        private Label label350;
        private TextBox textBox63;
        private Label label351;
        private TextBox textBox64;
        private Label label352;
        private Label label353;
        private Label label354;
        private Label label355;
        private Label label357;
        private Label label358;
        private Label label359;
        private GroupBox groupBox83;
        private ComboBox comboBox6;
        private Label label360;
        private TextBox textBox65;
        private Label label361;
        private Label label364;
        private Button button76;
        private Button button77;
        private Label label365;
        private GroupBox groupBox86;
        private Button btn_Z2stop_home;
        private Label label366;
        private Button btnScrewHome_Z2;
        private TextBox textBox66;
        private Label label367;
        private GroupBox groupBox88;
        private Button btn_Z2ScrewMove_stop;
        private Button btnScrewSVMove_Z2;
        private Label label368;
        private Label label369;
        private TextBox lbl_Z2ScrewSV_TargetSpeed;
        private Label label370;
        private TextBox lbl_Z2ScrewSV_TargetPosition;
        private Label label371;
        private GroupBox groupBox93;
        private Label lblScrewServoZ2disable;
        private Label label373;
        private Label lblScrewServoZ2Error;
        private Label label375;
        private Label lblScrewServoZ2Positive_limit;
        private Label label377;
        private Label lblScrewServoZ2Home;
        private Label lblScrewServoZ2Running;
        private Label lblScrewServoZ2Ready;
        private Label lblScrewServoZ2Negative_limit;
        private Label lblScrewServoZ2Enable;
        private Label label383;
        private Label label384;
        private Label label385;
        private Label label390;
        private Label label391;
        private TabPage Feeder;
        private Button button18;
        private Button button16;
        private Button button15;
        private Label label35;
        private TabControl tabFeeder;
        private TabPage Loader;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnBreakEnable_Loader;
        private Button btnBreakDisable_Loader;
        private GroupBox groupBox23;
        private Button btnServoLoaderEnable;
        private Button btnServoLoaderClearErr;
        private Button btnServoLoaderDisable;
        private GroupBox groupBox24;
        private Label label107;
        private Label lbl_loader_ActualPosition;
        private Label label109;
        private Label label112;
        private Label label113;
        private Label lbl_loader_ActualVelocity;
        private GroupBox groupBox25;
        private Button btnLoader_Stop;
        private Button btnLoader_Move_point;
        private TextBox textBox25;
        private TextBox textBox26;
        private TextBox textBox27;
        private Label label115;
        private Label label116;
        private TextBox textBox28;
        private Label label117;
        private TextBox textBox29;
        private Label label118;
        private Label label119;
        private Label label120;
        private Label label121;
        private Label label122;
        private Label label123;
        private Label label124;
        private GroupBox groupBox26;
        private ComboBox txtJogVelocity_LHloader;
        private Label label125;
        private TextBox txtJogDist_LHloader;
        private Label label126;
        private Label label127;
        private Button btnJogDec_Loader;
        private Button btnJogAdd_Loader;
        private Label label128;
        private GroupBox groupBox27;
        private Button btnHome_Stop_Loader;
        private Label label129;
        private Button btnHome_Loader;
        private TextBox textBox31;
        private Label label130;
        private GroupBox groupBox28;
        private Button btnMove_Stop_Loader;
        private Button btnMove_Loader;
        private Label label131;
        private Label label132;
        private TextBox txtLHLoader_TargetSpeed;
        private Label label133;
        private TextBox txtLHLoader_Targetposition;
        private Label label134;
        private GroupBox groupBox29;
        private Label lblServoDisableloader;
        private Label label188;
        private Label lblServoloader_Error;
        private Label label158;
        private Label lblServoloader_PositiveLimit;
        private Label label138;
        private Label lblServoloader_Home;
        private Label lblServoloader_Running;
        private Label lblServoloader_Ready;
        private Label lblServoloader_NegativeLimit;
        private Label lblServoloader_Enable;
        private Label label146;
        private Label label147;
        private Label label148;
        private Label label149;
        private Label label150;
        private TabPage Unloader;
        private GroupBox groupBox30;
        private GroupBox groupBox53;
        private Button btnUnloader_BreakEnable;
        private Button btnUnloader_BreakDisable;
        private GroupBox groupBox54;
        private Button btnUnloader_ServoEnable;
        private Button btnUnloader_ServoClearErr;
        private Button btnUnloader_ServoDisable;
        private GroupBox groupBox55;
        private Label label151;
        private Label lblUnloader_ActualPosition;
        private Label label153;
        private Label label156;
        private Label label157;
        private Label lblUnloader_ActualVelocity;
        private GroupBox groupBox56;
        private Button btnUnloader_Stop;
        private Button btnUnloader_Move_point;
        private TextBox textBox34;
        private TextBox textBox35;
        private TextBox textBox36;
        private Label label248;
        private Label label249;
        private TextBox textBox46;
        private Label label250;
        private TextBox textBox47;
        private Label label251;
        private Label label252;
        private Label label253;
        private Label label254;
        private Label label255;
        private Label label256;
        private Label label257;
        private GroupBox groupBox57;
        private ComboBox txtJogVelocity_LHUnloader;
        private Label label258;
        private TextBox txtJogDist_LHUnloader;
        private Label label259;
        private Label label260;
        private Button btnJogDec_Unloader;
        private Button btnJogAdd_Unloader;
        private Label label261;
        private GroupBox groupBox58;
        private Button btnUnloader_Home_Stop;
        private Label label262;
        private Button btnUnloader_Home;
        private TextBox textBox49;
        private Label label263;
        private GroupBox groupBox59;
        private Button btnUnloader_Stop_Move;
        private Button btnUnloader_Move;
        private Label label264;
        private Label label265;
        private TextBox txtLHUnLoader_TargetSpeed;
        private Label label266;
        private TextBox txtLHUnLoader_Targetposition;
        private Label label267;
        private GroupBox groupBox60;
        private Label lblServoDisableUnloader;
        private Label label242;
        private Label lblUnloader_Error;
        private Label label270;
        private Label lblUnloader_PositiveLimit;
        private Label label271;
        private Label lblUnloader_Home;
        private Label lblUnloader_Running;
        private Label lblUnloader_Ready;
        private Label lblUnloader_NegativeLimit;
        private Label lblUnloader_Enable;
        private Label label279;
        private Label label280;
        private Label label281;
        private Label label282;
        private Label label283;
        private TabPage Shuttle;
        private Button button31;
        private Button button30;
        private Label label36;
        private TabControl InternalShuttle;
        private TabPage Shuttle1;
        private GroupBox groupBox82;
        private GroupBox groupBox85;
        private Button btnShuttle1Enable;
        private Button btnShuttle1ClearErr;
        private Button btnShuttle1Disable;
        private GroupBox groupBox87;
        private Label label32;
        private Label lbl_Sh1_ActualPosition;
        private Label label356;
        private Label label362;
        private Label label363;
        private Label lbl_Shuttle1_TargetPosition;
        private GroupBox groupBox89;
        private Button btnStopPointS1;
        private Button btnMovePointS1;
        private TextBox textBox68;
        private TextBox textBox79;
        private TextBox textBox80;
        private Label label387;
        private Label label388;
        private TextBox textBox81;
        private Label label389;
        private TextBox textBox82;
        private Label label392;
        private Label label393;
        private Label label394;
        private Label label395;
        private Label label397;
        private Label label399;
        private Label label408;
        private GroupBox groupBox90;
        private ComboBox comboBox3;
        private Label label409;
        private TextBox textBox83;
        private Label label410;
        private Label label411;
        private Button btnJogDecS1;
        private Button btnJogAddS1;
        private Label label423;
        private GroupBox groupBox91;
        private Button btnHomeStopS1;
        private Label label424;
        private Button btnHomeS1;
        private TextBox textBox84;
        private Label label425;
        private GroupBox groupBox92;
        private Button btnMotionStopS1;
        private Button btnMotionMoveS1;
        private Label label426;
        private Label label427;
        private TextBox txtShuttle1_TargetSpeed;
        private Label label428;
        private TextBox txtServoS1_Targetposition;
        private Label label429;
        private GroupBox groupBox102;
        private Label lblSh1servoEnable;
        private Label lblSh1servo_PositiveLimit;
        private Label label431;
        private Label lblSh1servo_NegativeLimit;
        private Label label433;
        private Label lblSh1servoDisable;
        private Label label435;
        private Label lblSh1servo_Error;
        private Label label437;
        private Label lblSh1servo_Home;
        private Label label439;
        private Label label440;
        private Label label442;
        private Label label443;
        private Label label444;
        private Label label445;
        private TabPage Shuttle2;
        private GroupBox groupBox103;
        private GroupBox groupBox112;
        private Button btnShuttle2Enable;
        private Button btnShuttle2ClearErr;
        private Button btnShuttle2Disable;
        private GroupBox groupBox106;
        private Label label446;
        private Label lbl_Sh2_ActualPosition;
        private Label label448;
        private Label label449;
        private Label label450;
        private Label lbl_Shuttle2_TargetPosition;
        private GroupBox groupBox107;
        private Button btnStopPointS2;
        private Button btnMovePointS2;
        private TextBox textBox87;
        private TextBox textBox88;
        private TextBox textBox89;
        private Label label452;
        private Label label453;
        private TextBox textBox90;
        private Label label454;
        private TextBox textBox91;
        private Label label455;
        private Label label456;
        private Label label457;
        private Label label458;
        private Label label459;
        private Label label460;
        private Label label461;
        private GroupBox groupBox108;
        private ComboBox comboBox8;
        private Label label462;
        private TextBox textBox92;
        private Label label463;
        private Label label464;
        private Button btnJogDecS2;
        private Button btnJogAddS2;
        private Label label465;
        private GroupBox groupBox109;
        private Button btnHomeStopS2;
        private Label label466;
        private Button btnHomeS2;
        private TextBox textBox93;
        private Label label467;
        private GroupBox groupBox110;
        private Button btnMotionStopS2;
        private Button btnMotionMoveS2;
        private Label label468;
        private Label label469;
        private TextBox txtShuttle2_TargetSpeed;
        private Label label470;
        private TextBox txtServoS2_Targetposition;
        private Label label471;
        private GroupBox groupBox111;
        private Label lblSh2servo_PositiveLimit;
        private Label label473;
        private Label lblSh2servo_NegativeLimit;
        private Label label475;
        private Label lblSh2servoDisable;
        private Label label477;
        private Label lblSh2servo_Error;
        private Label label479;
        private Label lblSh2servo_Home;
        private Label label481;
        private Label label482;
        private Label lblSh2servoenable;
        private Label label484;
        private Label label485;
        private Label label486;
        private Label label487;
        private Panel AxisViewPanel;
        private Button button179;
        private Label label761;
        private Button button180;
        private Button button47;
        private TableLayoutPanel tableLayoutPanel1;
        private Timer timer1;
        private TabControl tabControl2;
        private TabPage tabPageAxis;
        private Panel ServosettingsPanel;
        private GroupBox groupBox3;
        private GroupBox groupBox12;
        private Label lblServoHomedColor;
        private Label label34;
        private Label lblServoErrorColor;
        private Label label38;
        private Label lblPosLimColor;
        private Label label40;
        private Label lblServoHomeColor;
        private Label lblServoRunningColor;
        private Label lblNegLimitColor;
        private Label lblServoEnableColor;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label51;
        private RichTextBox richTextBoxStatus;
        private GroupBox grbPTP;
        private Button btnPTP_Stop;
        private Button btnPTP_Move;
        private TextBox txtIteration;
        private TextBox txtWait;
        private TextBox txtPTP_Speed;
        private Label label93;
        private Label label94;
        private TextBox txtPTP_End;
        private Label label97;
        private TextBox txtPTP_Start;
        private Label label99;
        private Label label102;
        private Label label103;
        private Label label104;
        private Label label105;
        private Label label83;
        private Label label91;
        private GroupBox groupBox5;
        private Button btnServoEnable;
        private Button btnServoClear;
        private Button btnServoDisable;
        private GroupBox groupBox6;
        private Label label3;
        private Label lbl_Servo_Actual_Position;
        private Label label5;
        private Label label7;
        private Label label9;
        private Label lbl_Servo_TargetPosition;
        private GroupBox groupBox8;
        private Label label4;
        private TextBox txtJogSpeed;
        private Label label10;
        private Button btnJogReverse;
        private Button btnJogForward;
        private GroupBox groupBox10;
        private Button btnHomeStop;
        private Label label26;
        private Button btnHome;
        private TextBox txtHome_Velocity;
        private Label label27;
        private GroupBox groupBox11;
        private Button btnMoveStop;
        private Button btnMove;
        private Label label28;
        private Label label29;
        private TextBox txtServoX_Targetspeed;
        private Label label30;
        private TextBox txtServoX_Targetposition;
        private Label label31;
        private Panel AxisSelectPanel;
        private Label label2;
        private ComboBox AxisSelectCombo;
        private TabPage tabPageStepper;
        private TabPage tabPageCylinder;
        private Panel PnlCylinderMain;
        private TabPage tabPageVacuum;
        private Panel PnlVacuumMain;
        private TabPage tabPageRobot;
        private Panel panel2;
        private GroupBox grpRoboConn;
        private Button btnDisConnect;
        private Label lblCmd;
        private ComboBox cmbRBTmodeselect;
        private Label lblrobotconnstatus;
        private Label lblConnStatus;
        private Button btnconnect;
        public RichTextBox txtsendrobotcommand;
        public RichTextBox txtreceivecommnd;
        private Label label374;
        private Button btnRBTtrigger;
        private Label label376;
        private TabPage tabPageCamera;
        private GroupBox grpCCDConn;
        private Button btnCamDisConnect;
        private Label lblSelectCCD;
        private ComboBox cmbCCD;
        private Label lblCCDConnStatus;
        private Button btnCCDConnect;
        public RichTextBox txtSendCmd;
        public RichTextBox txtRecivdCmd;
        private Label label372;
        private Button btnCCDTrigger;
        private Label lblCCDConn;
        private Label label378;
        private TabPage tabPageLightControl;
        private GroupBox groupBox14;
        private Label label11;
        private ComboBox cmbCOMPort;
        private Button btnOPTDisconnect;
        private ComboBox cmbOPTSend;
        private Label lblOPTConStatus;
        private Button btnOPTConnect;
        public RichTextBox rtReceiveOPT;
        private Label label16;
        private Button btnOPTTrigger;
        private Label label17;
        private Label label18;
        private TabPage tabPageScanner;
        private GroupBox grpScanner;
        private Button btnScnrDisconnect;
        private Label lblScannerSel;
        private ComboBox cmbScanner;
        private Label lblScanrConStatus;
        private Button btnScannerConnect;
        public RichTextBox txtScannerSend;
        public RichTextBox txtScannerRecieve;
        private Label label380;
        private Button btnScannerTrigger;
        private Label lblScannerConn;
        private Label label382;
        private TabPage tabPageSfcPdca;
        private GroupBox groupBox13;
        private GroupBox groupBox15;
        private Label lblServoErrorColor_Stp;
        private Label label22;
        private Label lblServoEnableColor_Stp;
        private Label label46;
        private GroupBox grp_IO_Conv_Stepper_2;
        private Button StpperServo_On;
        private Button button37;
        private Button button38;
        private GroupBox grp_IO_Conv_Stepper_1;
        private Label label80;
        private TextBox stp_Text;
        private Label label92;
        private Button button44;
        private Button button45;
        private Panel panel1;
        private Label label12;
        private ComboBox StepperAxisComb;
        private Button button20;
        private GroupBox grp_IO_Conv;
        private GroupBox groupBox41;
        private TextBox Conv_Status;
        private GroupBox groupBox42;
        private Button Conv_Reset;
        private Button Conv_Reverse;
        private Button Conv_Stop;
        private Button Conv_Forward;
        private GroupBox groupBox7;
        private Label label23;
        private Label label21;
        private Button btnPDCATrigger;
        public RichTextBox rtSendPDCA;
        public RichTextBox rtReceivePDCA;
        private Label label19;
        private Label label20;
        private Button btnSFCDisConnect;
        private Label lblSFCConStatus;
        private Button btnSFCConnect;
        public RichTextBox rtSendSFC;
        public RichTextBox rtReceiveSFC;
        private Label label13;
        private Button btnSFCTrigger;
        private Label label14;
        private Label label15;
        private ComboBox cmbConveyorStepperCombo;
    }
}