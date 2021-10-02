using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_JocelydeLeon_1305619
{
    public class Scanner
    {
        private string _regexp = "";
        private int _index = 0;
        private int _state = 0;
        public Scanner(string regexp)
        {
            _regexp = regexp + (char)TokenType.EOF;
            _index = 0;
            _state = 0;
        }
        public Token GetToken()
        {
            Token result = new Token() { Value = (char)0 };
            bool tokenFound = false;
            while (!tokenFound)
            {
                char peek = _regexp[_index];
                switch (_state)
                {
                    case 0:
                        //whitespace removal
                        while (char.IsWhiteSpace(peek))
                        {
                            peek = _regexp[_index];
                            _index++;
                        }
                        switch (peek)
                        {
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:
                            case (char)TokenType.Minus:
                            case (char)TokenType.Plus:
                            case (char)TokenType.Multiplication:
                            case (char)TokenType.Division:
                            case (char)TokenType.EOF:
                                tokenFound = true;
                                result.Tag = (TokenType)peek;
                                result.Value = peek;
                                break;
                            case (char)TokenType.Empty:
                                tokenFound = true;
                                result.Tag = TokenType.Empty;
                                result.Value = peek;
                                break;
                            default:
                                //Num
                                if (char.IsDigit(peek))
                                {
                                    tokenFound = true;
                                    result.Tag = TokenType.Num;
                                    result.Value = peek;
                                }
                                else
                                {
                                    throw new Exception("Debe ingresar dígitos");
                                }
                                break;
                        }// SWITCH - peek

                        break; //Case 0

                    default:
                        break;
                } //SWITCH - state
                _index++;
            } //WHILE- tokenFound 
            return result;

        } //GetToken
    }
}
