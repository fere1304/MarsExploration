//using Codecool.MarsExploration.MapExplorer.Analizer;

//namespace Codecool.MarsExploration.MapExplorer.MarsRover;

//public class OutcomeAnalyzer
//{
//    private List
//}
//public class OutcomeAnalyzer
//{
    

//    public bool IsOutcomeReached(double[] map, int currentStep, int timeoutAmount)
//    {
//        foreach (var analyzer in analyzers)
//        {
//            if (analyzer.Analyze(map, currentStep, timeoutAmount))
//            {
//                return true;
//            }
//        }

//        return false;
//    }

//    public class SuccessAnalyzer
//    {
//        public bool Analyze(double[] map, int currentStep, int timeoutAmount)
//        {
//            int mineralCount = 0;
//            int waterCount = 0;
//            foreach (double item in map)
//            {
//                if (item == 1.0) mineralCount++;
//                if (item == 2.0) waterCount++;
//            }
//            return mineralCount == 4 && waterCount == 3;
//        }
//    }

//    public class LackOfResourcesAnalyzer : IAnalyzer
//    {
//        public bool Analyze(double[] map, int currentStep, int timeoutAmount)
//        {
//            int unexploredCount = 0;
//            foreach (double item in map)
//            {
//                if (item == 0.0) unexploredCount++;
//            }
//            return unexploredCount == 1;
//        }
//    }
//}

