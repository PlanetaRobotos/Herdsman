using System;
using System.Collections.Generic;
using _Project.ClientData.Leaderboards;
using MVVM.Collections;
using UnityEngine;

namespace _Project.Windows.Loading.Providers
{
    public class LeaderboardListView : BaseListView<ILeaderboardUserData, LeaderboardUserViewModel>
    {
        [Serializable]
        public class LeaderPlacements<TModel, TView>
            where TView : ModelView<TModel>
        {
            [field:SerializeField]
            public Transform ParentView { get; private set; }

            [field:SerializeField]
            public GameObject EmptyView { get; private set; }
        
            public TView CurrentViewModel { get; set; }
        }
    
        [SerializeField]
        private List<LeaderPlacements<ILeaderboardUserData, LeaderboardUserViewModel>> _leaderPlacements;
    
        [SerializeField]
        private List<LeaderboardUserViewModel> _leaderTemplates;
    
    

        protected override LeaderboardUserViewModel InstantiateView(ILeaderboardUserData item)
        {
            if (item.RatingPosition <= _leaderTemplates.Count)
            {
                var placement = _leaderPlacements.Find(x => x.CurrentViewModel == null);
                if(placement != null)
                {
                    return InstantiateViewInPlacement(item, placement);
                }
            }

            return base.InstantiateView(item);
        }

        private LeaderboardUserViewModel InstantiateViewInPlacement(ILeaderboardUserData item, LeaderPlacements<ILeaderboardUserData, LeaderboardUserViewModel> placement)
        {
            int index = item.RatingPosition - 1;
            var viewModel = Instantiate(_leaderTemplates[index], placement.ParentView);
            placement.CurrentViewModel = viewModel;
            placement.EmptyView.SetActive(false);
            viewModel.SetModel(item);
            return viewModel;
        }

        protected override void DestroyView(LeaderboardUserViewModel viewModel)
        {
            var leader = _leaderPlacements.Find(x => x.CurrentViewModel == viewModel);
            if (leader != null)
            {
                Destroy(leader.CurrentViewModel.gameObject);
                leader.EmptyView.SetActive(true);
            }
            else
            {
                base.DestroyView(viewModel);
            }
        }
    }
}
