﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ACT7_Course
{
    internal class Pari
    {
        private Personne _personne;
        private Chien _chien;
        private int _mise;

        public Personne Personne
        {
            get { return _personne; }
        }

        public Chien Chien
        {
            get { return _chien; }
        }

        public int Mise
        {
            get { return _mise; }
        }

        public Pari(Personne personne ,Chien chien, int mise)
        {
            _personne = personne;
            _chien = chien;
            _mise = mise;
        }
    }
}
