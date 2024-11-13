
namespace WindowsFormsApp7
{
   partial class Form1
   {
      /// <summary>
      /// Обязательная переменная конструктора.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Освободить все используемые ресурсы.
      /// </summary>
      /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Код, автоматически созданный конструктором форм Windows

      /// <summary>
      /// Требуемый метод для поддержки конструктора — не изменяйте 
      /// содержимое этого метода с помощью редактора кода.
      /// </summary>
      private void InitializeComponent()
      {
         this.trackBar2 = new System.Windows.Forms.TrackBar();
         this.label1 = new System.Windows.Forms.Label();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.openGLControl1 = new SharpGL.OpenGLControl();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
         this.SuspendLayout();
         // 
         // trackBar2
         // 
         this.trackBar2.Location = new System.Drawing.Point(748, 56);
         this.trackBar2.Maximum = 200;
         this.trackBar2.Minimum = 1;
         this.trackBar2.Name = "trackBar2";
         this.trackBar2.Size = new System.Drawing.Size(209, 45);
         this.trackBar2.TabIndex = 2;
         this.trackBar2.Value = 10;
         this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label1.Location = new System.Drawing.Point(732, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(233, 19);
         this.label1.TabIndex = 3;
         this.label1.Text = "Изменение силы тока 10^-2 A";
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(759, 125);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(83, 20);
         this.textBox1.TabIndex = 5;
         this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(871, 125);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(86, 20);
         this.textBox2.TabIndex = 6;
         this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label3.Location = new System.Drawing.Point(756, 104);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(67, 18);
         this.label3.TabIndex = 7;
         this.label3.Text = "Широта:";
         this.label3.Click += new System.EventHandler(this.label3_Click);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label4.Location = new System.Drawing.Point(868, 104);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(69, 18);
         this.label4.TabIndex = 8;
         this.label4.Text = "Долгота:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(833, 32);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(0, 13);
         this.label2.TabIndex = 9;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(780, 40);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(120, 13);
         this.label5.TabIndex = 10;
         this.label5.Text = "  Текущие зачение: 10";
         this.label5.Click += new System.EventHandler(this.label5_Click);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(759, 172);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 17;
         this.button1.Text = "Запустить";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // openGLControl1
         // 
         this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Left;
         this.openGLControl1.DrawFPS = false;
         this.openGLControl1.Location = new System.Drawing.Point(0, 0);
         this.openGLControl1.Name = "openGLControl1";
         this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
         this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
         this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
         this.openGLControl1.Size = new System.Drawing.Size(730, 602);
         this.openGLControl1.TabIndex = 18;
         this.openGLControl1.OpenGLInitialized += new System.EventHandler(this.openGLControl1_OpenGLInitialized);
         this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
         this.openGLControl1.Resized += new System.EventHandler(this.openGLControl1_Resized);
         this.openGLControl1.Load += new System.EventHandler(this.openGLControl1_Load);
         this.openGLControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyDown);
         this.openGLControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseClick);
         this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseMove);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(733, 211);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(0, 13);
         this.label6.TabIndex = 20;
         this.label6.Click += new System.EventHandler(this.label6_Click);
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(733, 242);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(0, 13);
         this.label7.TabIndex = 21;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(977, 602);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.openGLControl1);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.textBox2);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.trackBar2);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
         ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.TrackBar trackBar2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Button button1;
      private SharpGL.OpenGLControl openGLControl1;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
   }
}

