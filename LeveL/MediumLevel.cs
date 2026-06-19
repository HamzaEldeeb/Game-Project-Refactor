
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor.LeveL
{
    public class MediumLevel : BaseLevel
    {
        public override int Min => 0;
        public override int Max => 15;
        public override int NumberOfQuestions => 7;
        public override char[] Operators => new char[] { '+', '-', '*' };


    }
}
