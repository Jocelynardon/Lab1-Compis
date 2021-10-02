using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_JocelydeLeon_1305619
{
    public enum TokenType
    {
        Plus = '+',
        Minus = '-',
        Multiplication='*',
        Division ='/',
        LParen='(',
        RParen=')',
        EOF=(char)0,
        Empty=(char)1,
        Num=(char)2
    }
}
