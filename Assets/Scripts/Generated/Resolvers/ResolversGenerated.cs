using System; using System.Collections.Generic;
using _Project.Infrastructure.ReactiveAnimations;
using _Project.Windows.Loading.Providers;
using MVVM;using UnityEngine; namespace MVVM.Generated{    
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
                    
                public class Resolver_TestVM: IResolver
                {
                        private Dictionary<string, Func<TestVM, IReactiveProperty>> map = new()
                        {
                            { "TestBool", o => o.TestBool },
                        };

                        public IReactiveProperty Map(UnityEngine.Object target, string name)
                        {
                            return map[name].Invoke(target as TestVM);
                        }
                }
                    
                public class Resolver_Windows_Loading_Providers_LeaderboardUserViewModel: IResolver
                {
                        private Dictionary<string, Func<LeaderboardUserViewModel, IReactiveProperty>> map = new()
                        {
                            { "AvatarModel", o => o.AvatarModel },
{ "IsPlayer", o => o.IsPlayer },
{ "IsVip", o => o.IsVip },
{ "PlayerName", o => o.PlayerName },
{ "RatingPosition", o => o.RatingPosition },
{ "RatingScore", o => o.RatingScore },
                        };

                        public IReactiveProperty Map(UnityEngine.Object target, string name)
                        {
                            return map[name].Invoke(target as LeaderboardUserViewModel);
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
{typeof(TestVM),new Resolver_TestVM()},
{typeof(LeaderboardUserViewModel),new Resolver_Windows_Loading_Providers_LeaderboardUserViewModel()},    
                });
            }
        }}