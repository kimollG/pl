using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractElement;

namespace Plugin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPlugin();
            GetCommands();
        }
        private string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private List<Type> _plugins = new List<Type>();
        void LoadPlugin()
        {
            var dlls = System.IO.Directory.EnumerateFiles(dir, "*.dll");
            var aaa=dlls.ToArray();
            foreach (var dll in dlls)
            {
                try
                {
                    //Assembly a = Assembly.Load(dll);
                    //загрузка файлов
                    var a = System.Reflection.Assembly.LoadFile(dll);
                    var types = a.GetTypes();

                    //для каждого класса в либе...
                    foreach (var t in types)
                    {
                        //все интерфейсы, которые реализует выбранный класс
                        var interfaces = t.GetInterfaces();
                        //проверка, что среди них есть искомая командв
                        foreach (var i in interfaces)
                        {
                            if (i.Name.Equals((typeof(IDiagramShower<>)).Name))
                            {
                                //если подходит, добавляем на тип
                                _plugins.Add(t);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //...
                }
            }
        }
        public void GetCommands()
        {
            var result = new List<AbstractElement.IDiagramShower<Type>>();

            //Type t = _plugins[i];
            foreach (Type t in _plugins)
            {
                // это рефлексия (погуглите). создаем экземпляр класса по его типу
                result.Add(System.Activator.CreateInstance(t) as IDiagramShower<Type>);
            }

            foreach (var item in result)
            {
                item.DrawDiagram();
            }

        }
    }
}
