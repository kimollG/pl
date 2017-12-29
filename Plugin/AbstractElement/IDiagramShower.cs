using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace AbstractElement
{
    public interface IDiagramShower<T>
    {
        
        IEnumerable<T> Elements { get; set; }
        Measure<T> MeasureExpression { get; set; }
        void DrawDiagram();
    }
    public delegate double Measure<T>(T elem);
}
