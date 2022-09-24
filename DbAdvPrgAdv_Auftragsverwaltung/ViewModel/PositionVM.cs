using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    internal class PositionVM
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IOrderRepository _orderRepository;
        public PositionVM(IPositionRepository posRepo, IArticleRepository artRepo, IOrderRepository ordRepo)
        {
            _positionRepository = posRepo;
            _articleRepository = artRepo;
            _orderRepository = ordRepo;
        }
        public void AddPosition(Position entity)
        {
            _positionRepository.Add(entity);
        }
        public void UpdatePosition(Position entity)
        {
            _positionRepository.Update(entity);
        }
        public Position GetPositionById(int orderId, int articleId)
        {
            return _positionRepository.GetByCombinedId(orderId, articleId);
        }
        public List<Article> GetAllArticles()
        {
            return _articleRepository.GetAll();
        }
        public Article GetArticleById(int id)
        {
            return _articleRepository.GetById(id);
        }
        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
