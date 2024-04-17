using Mediatheque.Core.DAL;
using Mediatheque.Core.Model;

namespace Mediatheque.Core.Service
{
    public class MediathequeService
    {

        private List<ObjetDePret> _fondDeCommerce = new List<ObjetDePret>();
        private INotationService _notationService;
        private ApplicationDbContext _applicationDbContext;


        public MediathequeService( ApplicationDbContext applicationDbContext)
        {
           // _notationService = notationService;
            _applicationDbContext = applicationDbContext;
        }

        public MediathequeService(INotationService notationService)
        {
            _notationService = notationService;
        }

        public void AddObjet(ObjetDePret objet)
        {
            _fondDeCommerce.Add(objet);
        }

        public int GetNombreObjet()
        {
            return _fondDeCommerce.Count;
        }
        public List<CD> GetCDs()
   {
            return _applicationDbContext.CDs.ToList();
        }

        public CD AddCd(string album, string groupe)
        {
            CD cd = new CD(album, groupe);
            this._applicationDbContext.CDs.Add(cd);
            this._applicationDbContext.SaveChanges();
            return cd;
        }

        public CD GetCdById(int cdId)
        {
            return _applicationDbContext.CDs.Find(cdId);
        }

        public List<CD> GetCdsByGroupe(string groupe)
        {
            //Ici aucune requête n'est encore faite
            IQueryable<CD> query = this._applicationDbContext.CDs
                .Where(cd => cd.Groupe == groupe);

            //C'est ici que l'accès à la base est réalisée
            var cds = query.ToList();
            return query.ToList();
        }

        public void DeleteCD(int cdId)
        {
            var CdToDelete = this.GetCdById(cdId);
            this._applicationDbContext.CDs.Remove(CdToDelete);
            this._applicationDbContext.SaveChanges();
        }

        public void EditCd(int cdId, string albumModified)
        {
            var cd = this.GetCdById(cdId);
            cd.TitreDeLObjet = albumModified;
            this._applicationDbContext.SaveChanges();
        }
    }
}
