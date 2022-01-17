using FinalProject.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.PageObject
{
    public class InitPages : Base
    {
        public  static  void Init()
        {
            autoPanda = new Automationpanda();
            paraBank = new ParaBank();


        }

    }

}
