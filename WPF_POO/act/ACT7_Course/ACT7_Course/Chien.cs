using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACT7_Course
{
    internal class Chien
    {
        private int _numero;
        private Image _image;
        private int _position = 0;

        public int Numero
        {
            get { return _numero; }
        }

        public int Position
        {
            get { return _position; }
        }

        public Chien(int numero, Image image)
        {
            _numero = numero;
            _image = image;
        }

        public void Avancer()
        {
            Random random = new Random();
            _position += random.Next(0, 5);
        }
    }
}
