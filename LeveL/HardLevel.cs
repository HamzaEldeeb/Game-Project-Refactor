
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor.LeveL
{

    public class HardLevel : BaseLevel
    {
        public override int Min => 0;
        public override int Max => 20;
        public override int NumberOfQuestions => 8;
        public override char[] Operators => new char[] { '+', '-', '*', '/' };


    }
}
