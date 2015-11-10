using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
[Serializable]
public abstract class fuzzyFuncs
{
    public string fuzzyName;
    public string parent;
    protected List<PointF> values;
    public fuzzyFuncs()
    { 
    
    }
    public abstract List<PointF> getValues();
    public abstract List<PointF> getValues(float r);
    public abstract string getParamStr();
    public abstract double getFx(double x);
    public abstract double getMin();
    public abstract double getMax();
    public abstract double getIntervalLeft();
    public abstract double getIntervalRight();
    public abstract void setVlas(double a, double b, double c, double d);

    public abstract void setValues(double a, double b, double c, double d);
    public abstract fuzzyFuncs getClone();
}
[Serializable]
public class zLinear: fuzzyFuncs
{
    public double A, B;
    public zLinear(string par, string str, double A, double B)
    {
        this.A = A;
        this.B = B;
        this.fuzzyName = str;
        this.parent = par;
        values = new List<PointF>();
        values.Add(new PointF(0.0f, 1.0f));
        values.Add(new PointF((float)A, 1.0f));
        values.Add(new PointF((float)B, 0.0f));
    }
    public zLinear(double A, double B)
    {
        this.A = A;
        this.B = B;
        values = new List<PointF>();
        values.Add(new PointF(0.0f, 1.0f));
        values.Add(new PointF((float)A, 1.0f));
        values.Add(new PointF((float)B, 0.0f));
    }
    public override fuzzyFuncs getClone()
    {
        return new zLinear(parent, fuzzyName, A, B);
    }
    public override List<PointF> getValues()
    {
        return values;
    }
    public override List<PointF> getValues(float r)
    {
        List<PointF> values = new List<PointF>();
        values.Add(new PointF(0.0f, 0.0f));
        values.Add(new PointF(0.0f, r));
        values.Add(new PointF((float)(B - (B - A) * r), r));
        values.Add(new PointF((float)B, 0.0f));
        return values;
    }
    public override string getParamStr()
    {
        return "A [" + A.ToString("N2") + "] B[" + B.ToString("N2") + "]";
    }
    public override double getFx(double x)
    {
        double result = 0;
        if (x <= A)
        {
            result = 1.0;
        }
        else if (x > A && x <= B)
        { 
            result = (B-x)/(B-A);
        }
        else if (x > B)
        {
            result = 0.0;
        }
        return result;
    }
    public override double getMin() { return A; }
    public override double getMax() { return B; }
    public override double getIntervalLeft() { return A; }
    public override double getIntervalRight() { return A; }
    public override void setVlas(double a, double b, double c, double d)
    {
        A = a;
        B = d;
    }
    public override void setValues(double a, double b, double c, double d)
    {
        A = a;
        B = b;

        values = new List<PointF>();
        values.Add(new PointF(0.0f, 1.0f));
        values.Add(new PointF((float)A, 1.0f));
        values.Add(new PointF((float)B, 0.0f));
    }
}
[Serializable]
public class sLinear : fuzzyFuncs
{
    public double A, B;
    public sLinear(string par,string str, double A, double B)
    {
        this.A = A;
        this.B = B;
        this.fuzzyName = str;
        this.parent = par;
        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF(100.0f, 1.0f));
    }
    public sLinear(double A, double B)
    {
        this.A = A;
        this.B = B;
        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF(100.0f, 1.0f));
    }
    public override fuzzyFuncs getClone()
    {
        return new sLinear(parent, fuzzyName, A, B);
    }
    public override List<PointF> getValues()
    {
        return values;
    }
    public override List<PointF> getValues(float r)
    {
        List<PointF> values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)(A + (B - A) * r), r));
        values.Add(new PointF(100.0f, r));
        values.Add(new PointF(100.0f, 0.0f));
        return values;
    }
    public override string getParamStr()
    {
        return "A [" + A.ToString("N2") + "] B[" + B.ToString("N2") + "]";
    }
    public override double getFx(double x)
    {
        double result = 0;
        if (x > B)
        {
            result = 1.0;
        }
        else if (x >= A && x <= B)
        {
            result = (x - A) / (B - A);
        }
        else if (x < A)
        {
            result = 0.0;
        }
        return result;
    }
    public override double getMin() { return A; }
    public override double getMax() { return B; }
    public override double getIntervalLeft() { return B; }
    public override double getIntervalRight() { return B; }
    public override void setVlas(double a, double b, double c, double d)
    {
        A = a;
        B = d;
    }
    public override void setValues(double a, double b, double c, double d)
    {
        A = a;
        B = b;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF(100.0f, 1.0f));
    }
}
[Serializable]
public class triangleFunc : fuzzyFuncs
{
    public double A, B, C;
    public triangleFunc(string par, string str, double A, double B, double C)
    {
        this.A = A;
        this.B = B;
        this.C = C;
        this.fuzzyName = str;
        this.parent = par;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF((float)C, 0.0f));
    }
    public triangleFunc(double A, double B, double C)
    {
        this.A = A;
        this.B = B;
        this.C = C;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF((float)C, 0.0f));
    }
    public override fuzzyFuncs getClone()
    {
        return new triangleFunc(parent, fuzzyName, A, B, C);
    }
    public override List<PointF> getValues()
    {
        return values;
    }
    public override List<PointF> getValues(float r)
    {
        List<PointF> values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)(A + (B - A) * r), r));
        values.Add(new PointF((float)(C - (C - B) * r), r));
        values.Add(new PointF((float)C, 0.0f));
        return values;
    }

    public override string getParamStr()
    {
        return "A [" + A.ToString("N2") + "] B[" + B.ToString("N2") + "] C[" + C.ToString("N2") + "]";
    }
    public override double getFx(double x)
    {
        double result = 0;
        if (x < A)
        {
            result = 0.0;
        }
        else if (x > C)
        {
            result = 0.0;
        }
        else if (x >= A && x <= B)
        {
            result = (x - A) / (B - A);
        }
        else if (x > B && x <= C)
        {
            result = (C - x) / (C - B);
        }
        return result;
    }
    public override double getMin() { return A; }
    public override double getMax() { return C; }
    public override double getIntervalLeft() { return B; }
    public override double getIntervalRight() { return B; }
    public override void setVlas(double a, double b, double c, double d)
    {
        A = a;
        B = (b+c)/2.0;
        C = d;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF((float)C, 0.0f));
    }
    public override void setValues(double a, double b, double c, double d)
    {
        A = a;
        B = b;
        C = c;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF((float)C, 0.0f));
    }
}
[Serializable]
public class trapFunc : fuzzyFuncs
{
    public double A, B, C, D;
    public trapFunc(string par, string str, double A, double B, double C, double D)
    {
        this.A = A;
        this.B = B;
        this.C = C;
        this.D = D;
        this.fuzzyName = str;
        this.parent = par;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF((float)C, 1.0f));
        values.Add(new PointF((float)D, 0.0f));
    }
    public trapFunc(double A, double B, double C, double D)
    {
        this.A = A;
        this.B = B;
        this.C = C;
        this.D = D;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF((float)C, 1.0f));
        values.Add(new PointF((float)D, 0.0f));
    }
    public override List<PointF> getValues()
    {
        return values;
    }
    public override List<PointF> getValues(float r)
    {
        List<PointF> values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)(A + (B - A) * r), r));
        values.Add(new PointF((float)(D - (D - C) * r), r));
        values.Add(new PointF((float)D, 0.0f));
        return values;
    }
    public override string getParamStr()
    {
        return "A [" + A.ToString("N2") + "] B[" + B.ToString("N2") + "] C[" + C.ToString("N2") + "] D[" + D.ToString("N2") + "]";
    }
    public override double getFx(double x)
    {
        double result = 0;
        if (x < A)
        {
            result = 0.0;
        }
        else if (x > D)
        {
            result = 0.0;
        }
        else if (x >= B && x <= C)
        {
            result = 1.0;
        }
        else if (x > C && x <= D)
        {
            result = (D - x) / (D - C);
        }
        else if (x > A && x <= B)
        {
            result = (B - x) / (B - A);
        }
        return result;
    }
    public override double getMin() { return A; }
    public override double getMax() { return D; }
    public override double getIntervalLeft() { return B; }
    public override double getIntervalRight() { return C; }
    public override void setVlas(double a, double b, double c, double d)
    {
        A = a;
        B = b;
        C = c;
        D = d;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF((float)C, 1.0f));
        values.Add(new PointF((float)D, 0.0f));
    }
    public override fuzzyFuncs getClone()
    {
        return new trapFunc(parent, fuzzyName, A, B, C, D);
    }
    public override void setValues(double a, double b, double c, double d)
    {
        A = a;
        B = b;
        C = c;
        D = d;

        values = new List<PointF>();
        values.Add(new PointF((float)A, 0.0f));
        values.Add(new PointF((float)B, 1.0f));
        values.Add(new PointF((float)C, 1.0f));
        values.Add(new PointF((float)D, 0.0f));
    }
}
[Serializable]
public struct inRule
{
    public inRule(fuzzyLingvo lingvo, string termName)
    {
        this.lingvo = lingvo;
        this.termName = termName;
    }
    public fuzzyFuncs getFuzzyFunc()
    {
        return lingvo.getTerm(termName);
    }
    public fuzzyLingvo lingvo;
    public string termName;
}
[Serializable]
public class fuzzyRule
{
    //public List<fuzzyFuncs> inFunc = null;
    public List<inRule> inFunc = null;
    char opType;
    public string outTerm;

    public fuzzyRule(List<inRule> inFunc, char opType, string outTerm)
    {
        this.opType = opType;
        this.inFunc = inFunc;
        this.outTerm = outTerm;
    }

    public double commitRule(double inTime, double inConsult, double inCost)
    {
        double res = 0.0;
        List<double> tmp = new List<double>();
        for (int i = 0; i < inFunc.Count; i++)
        {
            inRule inRule = inFunc[i];
            switch (inRule.lingvo.nameLingvo)
            {
                case "Оперативность обслуживания":
                    tmp.Add(inRule.getFuzzyFunc().getFx(inTime));
                    break;
                case "Техническая поддержка (консультации)":
                    tmp.Add(inRule.getFuzzyFunc().getFx(inConsult));
                    break;
                case "Стоимость услуг":
                    tmp.Add(inRule.getFuzzyFunc().getFx(inCost));
                    break;
            }

        }

        tmp.Sort();//???? A
        res = tmp[0];
        return res;
    }
}
[Serializable]
public class fuzzyModel1
{
    public fuzzyLingvo inTime = new fuzzyLingvo("Оперативность обслуживания",10.0);
    public fuzzyLingvo inConsult = new fuzzyLingvo("Техническая поддержка (консультации)",10.0);
    public fuzzyLingvo inCost = new fuzzyLingvo("Стоимость услуг",8.0);

    public fuzzyLingvo outService = new fuzzyLingvo("Качество услуг", 10.0);

    public List<fuzzyRule> rules = new List<fuzzyRule>();

    public fuzzyModel1()
    {
  /*      //оперативность
        inTime.addTerm(new trapFunc("Оперативность обслуживания", "Низкая (приходится ждать)", 0, 2, 3, 5));
        inTime.addTerm(new trapFunc("Оперативность обслуживания", "Удовлетворительная", 3, 5, 7, 8));
        inTime.addTerm(new trapFunc("Оперативность обслуживания", "Высокая", 7, 8, 9, 10));
        //техподдержка
        inConsult.addTerm(new triangleFunc("Техническая поддержка (консультации)", "Высококлассная", 5, 10, 10));
        inConsult.addTerm(new triangleFunc("Техническая поддержка (консультации)", "Средний уровень", 1, 4, 9));
        inConsult.addTerm(new triangleFunc("Техническая поддержка (консультации)", "Удовлетворительно", 0, 2, 4));
        inConsult.addTerm(new triangleFunc("Техническая поддержка (консультации)", "Неудовлетворительная", 0, 0.5, 1));
        //стоимсоть услуг
        inCost.addTerm(new triangleFunc("Стоимость услуг", "Высокая", 6, 8, 8));
        inCost.addTerm(new triangleFunc("Стоимость услуг", "Умеренная", 2, 5, 8));
        inCost.addTerm(new triangleFunc("Стоимость услуг", "Доступная всем слоям", 0, 2, 4));

        //качество услуг
        outService.addTerm(new trapFunc("Качество услуг", "Низкое", 0, 0.5, 2, 3));
        outService.addTerm(new trapFunc("Качество услуг", "Среднее", 1, 3, 4, 6));
        outService.addTerm(new trapFunc("Качество услуг", "Высокое", 5, 6, 7, 9));
        outService.addTerm(new trapFunc("Качество услуг", "Безупреченое", 8, 9, 10, 10));
 */   }

    public double[] interp(double inTime, double inConsult, double inCost)
    {
        double[] ret = new double[outService.funcs.Count+1];
        double[] res = new double[outService.funcs.Count];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = 0.0;
        }

        //1 идем по списку термов выхода
        for (int i = 0; i < outService.funcs.Count; i++)
        {
            for (int j = 0; j < rules.Count; j++)
            {
                if (outService.funcs[i].fuzzyName.CompareTo(rules[j].outTerm) == 0)
                {
                    res[i] = Math.Max(res[i], rules[j].commitRule(inTime, inConsult, inCost));
                }
            }
        }
        //2 теперь есть список  всех рейтингов
        double min = 100;
        double r_opt = 0;
        double newmin = 0;
        for (float r = 0; r <= 10.0f; r += 0.1f)
        {
            double mass1 = 0; // первая масса
            double mass2 = 0; // вторая масса
            //масса с одной стороны
            for (float i = 0; i <= r; i += 0.1f)
            {
                for (int n = 0; n < outService.funcs.Count; n++)
                {
                    double dn = outService.funcs[n].getFx(i);
                    if (dn > res[n])
                    {
                        dn = res[n];
                    }
                    mass1 += dn;
                }
            }
            //масса с другой стороны
            for (float i = 10; i >= r; i -= 0.1f)
            {
                for (int n = 0; n < outService.funcs.Count; n++)
                {
                    double dn = outService.funcs[n].getFx(i);
                    if (dn > res[n])
                    {
                        dn = res[n];
                    }
                    mass2 += dn;
                }
            }
            //если нашли лучший вариант
            //запоминаем его
            newmin = Math.Abs(mass1 - mass2);
            if (newmin < min)
            {
                r_opt = r;
                min = newmin;
            }
        }
        ret[0] = r_opt;
        for (int i = 0; i < outService.funcs.Count; i++)
        {
            ret[i + 1] = res[i];
        }
        return ret;
    }
}
[Serializable]
public class fuzzyProfit3
{
    public fuzzyFuncs app, cost, discount, count;
    public fuzzyProfit3()
    {
        app = new triangleFunc(200,300,800);
        cost = new trapFunc(250, 500, 800, 2000);
        discount = new trapFunc(3, 5, 7, 10);
        count = new triangleFunc(15, 20, 30);
        app.fuzzyName = "Обращения граждан (шт)";
        cost.fuzzyName = "Стоимость обслуживания (руб)";
        discount.fuzzyName = "Скидка льготным категориям (%)";
        count.fuzzyName = "Количество льготников (%)";
    }
    public fuzzyProfit3(fuzzyFuncs app,fuzzyFuncs cost,fuzzyFuncs discount,fuzzyFuncs count)
    {
        this.app = app;
        this.cost = cost;
        this.discount = discount;
        this.count = count;
        app.fuzzyName = "Обращения граждан (шт)";
        cost.fuzzyName = "Стоимость обслуживания (руб)";
        discount.fuzzyName = "Скидка льготным категориям (%)";
        count.fuzzyName = "Количество льготников (%)";
    }
    public void setAppFunc(fuzzyFuncs app)
    {
        this.app = app;
        this.app.fuzzyName = "Обращения граждан (шт)";
    }
    public void setCostFunc(fuzzyFuncs cost)
    {
        this.cost = cost;
        this.cost.fuzzyName = "Стоимость обслуживания (руб)";
    }
    public void setSkidkaFunc(fuzzyFuncs discount)
    {
        this.discount = discount;
        this.discount.fuzzyName = "Скидка льготным категориям (%)";
    }
    public void setCountFunc(fuzzyFuncs count)
    {
        this.count = count;
        this.count.fuzzyName = "Количество льготников (%)";
    }
    public double getMinProfit()
    {
        double _app = app.getMin();
        double _cost = cost.getMin();
        double _discount = discount.getMax();//%
        double _count = count.getMax();//%
        double numDiscounter = _app * (_count * 0.01);
        double numNormalClient = _app - numDiscounter;
        double costNormalClient = numNormalClient * _cost;
        double costDiscounter = numDiscounter * (_cost - _cost * (_discount * 0.01));
        return costNormalClient + costDiscounter;
    }
    public double getMaxProfit()
    {
        double _app = app.getMax();
        double _cost = cost.getMax();
        double _discount = discount.getMin();//%
        double _count = count.getMin();//%
        double numDiscounter = _app * (_count * 0.01);
        double numNormalClient = _app - numDiscounter;
        double costNormalClient = numNormalClient * _cost;
        double costDiscounter = numDiscounter * (_cost - _cost * (_discount * 0.01));
        return costNormalClient + costDiscounter;
    }
    public double getTrustMin()
    {
        double _app = app.getIntervalLeft();
        double _cost = cost.getIntervalLeft();
        double _discount = discount.getIntervalRight();//%
        double _count = count.getIntervalRight();//%
        double numDiscounter = _app * (_count * 0.01);
        double numNormalClient = _app - numDiscounter;
        double costNormalClient = numNormalClient * _cost;
        double costDiscounter = numDiscounter * (_cost - _cost * (_discount * 0.01));
        return costNormalClient + costDiscounter;
    }
    public double getTrustMax()
    {
        double _app = app.getIntervalRight();
        double _cost = cost.getIntervalRight();
        double _discount = discount.getIntervalLeft();//%
        double _count = count.getIntervalLeft();//%
        double numDiscounter = _app * (_count * 0.01);
        double numNormalClient = _app - numDiscounter;
        double costNormalClient = numNormalClient * _cost;
        double costDiscounter = numDiscounter * (_cost - _cost * (_discount * 0.01));
        return costNormalClient + costDiscounter;
    }
}
[Serializable]
public class fuzzyLingvo
{
    public List<fuzzyFuncs> funcs = new List<fuzzyFuncs>();
    public string nameLingvo;
    public double dist;
    public fuzzyLingvo(string name, double dist)
    {
        this.nameLingvo = name;
        this.dist = dist;
    }
    public void addTerm(fuzzyFuncs func)
    {
        funcs.Add(func);
    }
    public fuzzyFuncs getTerm(string name)
    {
        for (int i = 0; i < funcs.Count; i++)
        {
            if (funcs[i].fuzzyName.CompareTo(name) == 0)
            {
                return funcs[i];
            }
        }
        return null;
    }
    public void removeTerm(fuzzyFuncs func)
    {
        funcs.Remove(func);
    }
}