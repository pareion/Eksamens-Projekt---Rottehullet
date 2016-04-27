﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class AktivFactory
    {
        private static AktivFactory _aktivFactory;

        public static AktivFactory HentAktivFactory()
        {
            if (_aktivFactory == null)
            {
                _aktivFactory = new AktivFactory();
            }
            return _aktivFactory;
        }

        public Brætspil SkabNyBrætspil(int id, string navn, string udgiver)
        {
            return new Brætspil(id, navn,udgiver);
        }
        public Bog SkabNyBog(string titel, string forfatter, string genre, string subkategori, string familie, string forlag, string isbn, string kommentar = null)
        {
            return new Bog(titel, forfatter, genre, subkategori, familie, forlag, isbn, kommentar);
        }
        public Lokale SkabNytLokale(int id, string navn, string lokation, int størrelse, string møbler)
        {
            return new Lokale(id, navn, lokation, størrelse, møbler);
        }
    }
}
