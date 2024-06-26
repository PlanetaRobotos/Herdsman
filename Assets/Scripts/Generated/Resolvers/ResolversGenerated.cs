using System; using System.Collections.Generic;using MVVM;using UnityEngine; namespace MVVM.Generated{    
                public class Resolver__Project_Currencies_Views_BaseCurrencyView: IResolver
                {
                        private Dictionary<string, Func<_Project.Currencies.Views.BaseCurrencyView, IReactiveProperty>> map = new()
                        {
                            { "AmountChanged", o => o.AmountChanged },
{ "SmoothAmount", o => o.SmoothAmount },
                        };

                        public IReactiveProperty Map(UnityEngine.Object target, string name)
                        {
                            return map[name].Invoke(target as _Project.Currencies.Views.BaseCurrencyView);
                        }
                }
                    
                public class Resolver__Project_Infrastructure_ReactiveAnimations_TestVM: IResolver
                {
                        private Dictionary<string, Func<_Project.Infrastructure.ReactiveAnimations.TestVM, IReactiveProperty>> map = new()
                        {
                            { "TestBool", o => o.TestBool },
                        };

                        public IReactiveProperty Map(UnityEngine.Object target, string name)
                        {
                            return map[name].Invoke(target as _Project.Infrastructure.ReactiveAnimations.TestVM);
                        }
                }
                
        public static class BindersLoader
        {
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
            private static void InitResolvers()
            {
                Binders.AddResolvers(new()
                {
                    {typeof(_Project.Currencies.Views.BaseCurrencyView),new Resolver__Project_Currencies_Views_BaseCurrencyView()},
{typeof(_Project.Infrastructure.ReactiveAnimations.TestVM),new Resolver__Project_Infrastructure_ReactiveAnimations_TestVM()},    
                });
            }
        }}