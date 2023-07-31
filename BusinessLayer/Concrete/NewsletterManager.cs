using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NewsletterManager : INewsletterService
	{
		INewsletterDal _newsletterdal;

		public NewsletterManager(INewsletterDal newsletterdal)
		{
			_newsletterdal=newsletterdal;
		}

		public void Delete(NewsLetter t)
		{
			throw new NotImplementedException();
		}

		public NewsLetter GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<NewsLetter> GetList()
		{
			throw new NotImplementedException();
		}

		public List<NewsLetter> GetList(Expression<Func<NewsLetter, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void Insert(NewsLetter t)
		{
			_newsletterdal.Insert(t);
		}

		public void Update(NewsLetter t)
		{
			throw new NotImplementedException();
		}
	}
}
