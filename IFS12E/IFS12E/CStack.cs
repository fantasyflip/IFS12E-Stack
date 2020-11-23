﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS12E
{
    class CStack
    {
        private int i_size;
        private int[] ia_Stack;
        private int i_aktIndex;

        //Konstruktor
        public CStack(int i_newSize)
        {

        }

        public void setSize(int i_newSize)
        {
            if(i_newSize > 0)
            {
                this.i_size = i_newSize;
            }
        }

        public void setAktIndex(int i_newIndex)
        {
            if((i_newIndex > 0) && (i_newIndex < getSize()))
            {
                this.i_aktIndex = i_newIndex;
            }
        }

        public int getSize()
        {
            return this.i_size;
        }

        public int getAktIndex()
        {
            return this.i_aktIndex;
        }

        public void LowerIndexByOne()
        {
            this.i_aktIndex = i_aktIndex - 1;
        }

        public void HigherIndexByOne()
        {
            this.i_aktIndex = i_aktIndex + 1;
        }

        public bool Push(int i_zahl)
        {
            bool b_saved = false;

            if ((getAktIndex()+1) < getSize())
            {
                this.ia_Stack[getAktIndex()] = i_zahl;
                b_saved = true;
                HigherIndexByOne();
            }

            return b_saved;
        }

        public int Pop()
        {
            int i_ergebnis;
            i_ergebnis = this.ia_Stack[getAktIndex()];
            LowerIndexByOne();
            return i_ergebnis;

        }
    }
}