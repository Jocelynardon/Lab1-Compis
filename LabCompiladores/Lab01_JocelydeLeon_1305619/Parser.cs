using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_JocelydeLeon_1305619
{
    class Parser
    {
        Scanner _scanner;
        Token _token;
        private double E()
        {
            double first = 0;
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Num:
                case TokenType.Minus:
                    double resultF = T();
                    first = EP(resultF);
                    break;
            }
            return first;
        }
        //EP'
        private double EP(double ant)
        {
            double first = 0;
            double actual;
            double add;
            switch (_token.Tag)
            {
                case TokenType.Plus:
                    Match(TokenType.Plus);
                    actual = T();
                    add = ant + actual;
                    first = EP(add);
                    break;
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    actual = T();
                    add = ant - actual;
                    first = EP(add);
                    break;
                case TokenType.RParen:
                case TokenType.EOF:
                    first = ant;
                    break;
                default:
                    break;
            }
            return first;
        }
        private double F()
        {
            double first=0;
            switch (_token.Tag)
            {
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    double actual=Pos();
                    double minus = actual*-1;
                    first = minus;
                    break;
                case TokenType.Num:
                case TokenType.LParen:
                    first=Pos();
                    break;
                default:
                    break;
            }
            return first;
        }
        private double Pos()
        {
            double first=0;
            switch (_token.Tag)
            {
                case TokenType.Num:
                    double previous = double.Parse(_token.Value.ToString());
                    Match(TokenType.Num);
                    first = O(previous);
                    break;
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    first = E();
                    Match(TokenType.RParen);
                    break;
                default:
                    break;
            }
            return first;
        }
        private double O(double ant)
        {
            double first=0;
            switch (_token.Tag)
            {
                case TokenType.Num:
                    string conc = ant.ToString() + _token.Value.ToString();
                    Match(TokenType.Num);
                    first = O(double.Parse(conc));
                    break;
                case TokenType.Multiplication:
                case TokenType.Division:
                case TokenType.Plus:
                case TokenType.Minus:
                case TokenType.RParen:
                case TokenType.EOF:
                    first = ant;
                    break;
                default:
                    throw new Exception("Error de sintaxis");
                    break;
            }
            return first;
        }
        private double T()
        {
            double first=0;
            switch (_token.Tag)
            {

                case TokenType.LParen:
                case TokenType.Num:
                case TokenType.Minus:
                    double resultF= F();
                    first=TP(resultF);
                    break;
                default:
                    break;
            }
            return first;
        }
        private double TP(double ant)
        {
            double first=0;
            double firstF;
            switch (_token.Tag)
            {

                case TokenType.Multiplication:
                    Match(TokenType.Multiplication);
                    firstF=F();
                    double multi = ant * firstF;
                    first=TP(multi);
                    break;
                case TokenType.Division:
                    Match(TokenType.Division);
                    firstF = F();
                    double divi = ant / firstF;
                    first = TP(divi);
                    break;
                case TokenType.Plus:
                case TokenType.Minus:
                case TokenType.RParen:
                case TokenType.EOF:
                    first = ant;
                    break;
                default:
                    break;
            }
            return first;
        }
        private void Match(TokenType tag)
        {
            if (_token.Tag == tag)//Si lo logra identificar, necesito un nuevo token
            {
                _token = _scanner.GetToken();
            }
            else
            {
                throw new Exception("Error de sintaxis");
            }
        }
        public double Parse(string regexp)
        {
            double first=0;
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();
            switch (_token.Tag)
            {
                case TokenType.Num:
                case TokenType.LParen:
                case TokenType.Minus:
                    first=E();
                    break;
                default:
                    break;
            }
            Match(TokenType.EOF);
            return first;
        } //Parse
    } //Parser
}
