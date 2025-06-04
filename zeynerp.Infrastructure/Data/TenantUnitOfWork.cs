using zeynerp.Core.Interfaces;
using zeynerp.Core.Repositories.SatinalmaYonetimi;
using zeynerp.Core.Repositories.Tanimlamalar;

namespace zeynerp.Infrastructure.Data
{
    public class TenantUnitOfWork : ITenantUnitOfWork
    {
        private readonly IStokGrupRepository _stokGrupRepository;
        private readonly IStokOzellikRepository _stokOzellikRepository;
        private readonly IBirimRepository _birimRepository;
        private readonly IStokRepository _stokRepository;
        private readonly IMalzemeTalepRepository _malzemeTalepRepository;
        private readonly ICariTurRepository _cariTurRepository;

        public TenantUnitOfWork(IStokGrupRepository stokGrupRepository, IStokOzellikRepository stokOzellikRepository, IBirimRepository birimRepository, IStokRepository stokRepository, IMalzemeTalepRepository malzemeTalepRepository, ICariTurRepository cariTurRepository)
        {
            _stokGrupRepository = stokGrupRepository;
            _stokOzellikRepository = stokOzellikRepository;
            _birimRepository = birimRepository;
            _stokRepository = stokRepository;
            _malzemeTalepRepository = malzemeTalepRepository;
            _cariTurRepository = cariTurRepository;
        }

        public IStokGrupRepository StokGrupRepository => _stokGrupRepository;

        public IStokOzellikRepository StokOzellikRepository => _stokOzellikRepository;

        public IBirimRepository BirimRepository => _birimRepository;

        public IStokRepository StokRepository => _stokRepository;

        public IMalzemeTalepRepository MalzemeTalepRepository => _malzemeTalepRepository;

        public ICariTurRepository CariTurRepository => _cariTurRepository;
    }
}