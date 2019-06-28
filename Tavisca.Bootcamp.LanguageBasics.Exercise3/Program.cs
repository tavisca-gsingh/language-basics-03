using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {   
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }


        public static List<int> FindMinIndex(List<int> mealList,int[] category){
            var elements=new List<int>();
            foreach(int index in mealList){
                elements.Add(category[index]);
            }
            int min=elements.Min();
            elements.Clear();
            foreach(int index in mealList){
                if (category[index]==min){
                    elements.Add(index);
                }
            }
            return elements;
        }

        public static List<int> FindMaxIndex(List<int> mealList,int[] category){
            var elements=new List<int>();
            foreach(int index in mealList){
                elements.Add(category[index]);
            }
            int min=elements.Max();
            elements.Clear();
            foreach(int index in mealList){
                if (category[index]==min){
                    elements.Add(index);
                }
            }
            return elements;
        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {   int length=protein.Length;
            int[] calories=new int[length];
            int i;
            for(i=0;i<length;i++){
                calories[i]=protein[i]*5+carbs[i]*5+fat[i]*9;
            }
            int[] selectedDietPlans=new int[dietPlans.Length];
            List<int> selectedDietPlan=new List<int>();
            i=0;
            foreach(var dietplan in dietPlans){
                selectedDietPlan=Enumerable.Range(0,length).ToList();
                foreach(var element in dietplan){
                    if(element=='C'){
                        selectedDietPlan=FindMaxIndex(selectedDietPlan,carbs);
                    }
                    else if(element=='c'){
                        selectedDietPlan=FindMinIndex(selectedDietPlan,carbs);
                    }else if(element=='P'){
                        selectedDietPlan=FindMaxIndex(selectedDietPlan,protein);
                    }else if(element=='p'){
                        selectedDietPlan=FindMinIndex(selectedDietPlan,protein);
                    }else if(element=='F'){
                        selectedDietPlan=FindMaxIndex(selectedDietPlan,fat);
                    }else if(element=='f'){
                        selectedDietPlan=FindMinIndex(selectedDietPlan,fat);
                    }else if(element=='T'){
                        selectedDietPlan=FindMaxIndex(selectedDietPlan,calories);
                    }else if(element=='t'){
                        selectedDietPlan=FindMinIndex(selectedDietPlan,calories);
                    }
                    if(selectedDietPlan.Count==1){
                        break;
                    }
                }
                selectedDietPlans[i]=selectedDietPlan[0];
                i+=1;
            }
            return selectedDietPlans;
            throw new NotImplementedException();
        }
    }
}
