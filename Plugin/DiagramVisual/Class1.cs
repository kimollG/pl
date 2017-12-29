using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using AbstractElement;
using System.Reflection;

namespace Elements.Plugins
{       
    public class DiagramShower<T> : System.Windows.Forms.UserControl,IDiagramShower<T>
    {
        IEnumerable<T> data;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        Measure<T> expression;
        public IEnumerable<T> Elements
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public Measure<T> MeasureExpression
        {
            get
            {
                return expression;
            }

            set
            {
                expression = value;
            }
        }
        
        public void DrawDiagram()
        {
            if (expression == null || data == null)
                return;
            double[] vals = data.Select(t => expression(t)).ToArray();      
                  
        }
        
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DiagramShower
            // 
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DiagramShower";
            this.Size = new System.Drawing.Size(232, 200);
            this.ResumeLayout(false);

        }
    }
}
