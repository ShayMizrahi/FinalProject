using FinalProject.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.PageObject
{
    public class InitPages
    {
        public  static  void Init()
        {
            Base.autoPanda = new AutomationPanda();
            Base.paraBank = new ParaBank();

        }

    }

}
