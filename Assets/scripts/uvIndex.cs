using System.Runtime.CompilerServices.DynamicAttribute;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

public class PythonInstance{
    private ScriptEngine engine;
    private ScriptScope scope;
    private ScriptSource source;
    private CompiledCode compiled;
    private object pythonClass;

    public PythonInstance(string code, string className = "PyClass")
    {
        //creating engine and stuff
        engine = Python.CreateEngine();
        scope = engine.CreateScope();

        //loading and compiling code
        source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
        compiled = source.Compile();

        //now executing this code (the code should contain a class)
        compiled.Execute(scope);

        //now creating an object that could be used to access the stuff inside a python script
        pythonClass = engine.Operations.Invoke(scope.GetVariable(className));
    }

    public void SetVariable(string variable, dynamic value)
    {
        scope.SetVariable(variable, value);
    }

    public dynamic GetVariable(string variable)
    {
        return scope.GetVariable(variable);
    }

    public void CallMethod(string method, params dynamic[] arguments)
    {
        engine.Operations.InvokeMember(pythonClass, method, arguments);
    }

    public dynamic CallFunction(string method, params dynamic[] arguments)
    {
        return engine.Operations.InvokeMember(pythonClass, method, arguments);
    }
public static void main(string[] args) {
        PythonInstance py = new PythonInstance(@"
class PyClass:
    def __init__(self):
        pass

    def somemethod(self):
        print 'in some method'

    def isodd(self, n):
        return 1 == n % 2
");
        py.CallMethod("somemethod");
        Console.WriteLine(py.CallFunction("isodd", 6));
    }

}

//public class uvIndex : MonoBehaviour {

//    public Button button;
//	public Text txtAlert, txtAdvise, txtIv;
//	private string advise, alert;
//	double iv = 4.5;
//    public void changeAdvise()
//    {

        

//        if (iv == 0 ) {
//            alert = "low";
//            advise = "It's probably night outside, have a fun time!";
//        }

//        if(iv <= 2){
//            alert = "low";
//        advise= "- Wear sunglasses on bright days. \n" +
//                "- If you burn easily, cover up and use broad spectrum SPF 30+ sunscreen. \n" +
//                "- Watch out for bright surfaces, like sand, water and snow, which reflect UV and increase exposure.";

//        }
//        else if (iv <= 7)
//        {
//            alert = "Moderate";
//            advise = "Stay in shade near midday when the sun is strongest. \n" +
//                "If outdoors, wear protective clothing, a wide-brimmed hat, and UV-blocking sunglasses. \n" +
//                "Generously apply broad spectrum SPF 30+ sunscreen every 2 hours, even on cloudy days, and after swimming or sweating. \n" +
//                "Watch out for bright surfaces, like sand, water and snow, which reflect UV and increase exposure.";

//        }else if (iv <= 10)
//        {
//            alert = "High";
//            advise = "Stay in shade near midday when the sun is strongest. \n" +
//                "If outdoors, wear protective clothing, a wide-brimmed hat, and UV-blocking sunglasses. \n" +
//                "Generously apply broad spectrum SPF 30+ sunscreen every 2 hours, even on cloudy days, and after swimming or sweating. \n" +
//                "Watch out for bright surfaces, like sand, water and snow, which reflect UV and increase exposure. \n" +
//                "PLEASE! be really careful, you can easily damage your skin and eyes";


//        }
//        else
//        {
//            alert = "Extreme";
//            advise = "Stay in shade near midday when the sun is strongest. \n" +
//               "If outdoors, wear protective clothing, a wide-brimmed hat, and UV-blocking sunglasses. \n" +
//               "Generously apply broad spectrum SPF 30+ sunscreen every 2 hours, even on cloudy days, and after swimming or sweating. \n" +
//               "Watch out for bright surfaces, like sand, water and snow, which reflect UV and increase exposure. \n" +
//               "PLEASE! your eyes and skin can burn in about 10 minutes";

//        }

//        Debug.Log(alert);

//        txtIv.text = iv.ToString();
//        txtAlert.text = alert;
//        txtAdvise.text = advise;

//    }


//}
