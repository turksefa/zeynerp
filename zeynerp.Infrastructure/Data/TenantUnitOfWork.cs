using zeynerp.Core.Interfaces;
using zeynerp.Core.Repositories.Tanimlamalar;

namespace zeynerp.Infrastructure.Data
{
    public class TenantUnitOfWork : ITenantUnitOfWork
    {
        private readonly IStokGrupRepository _stokGrupRepository;
        private readonly IStokOzellikRepository _stokOzellikRepository;
        private readonly IBirimRepository _birimRepository;
        private readonly IStokRepository _stokRepository;

        public TenantUnitOfWork(IStokGrupRepository stokGrupRepository, IStokOzellikRepository stokOzellikRepository, IBirimRepository birimRepository, IStokRepository stokRepository)
        {
            _stokGrupRepository = stokGrupRepository;
            _stokOzellikRepository = stokOzellikRepository;
            _birimRepository = birimRepository;
            _stokRepository = stokRepository;
        }

        public IStokGrupRepository StokGrupRepository => _stokGrupRepository;

        public IStokOzellikRepository StokOzellikRepository => _stokOzellikRepository;

        public IBirimRepository BirimRepository => _birimRepository;

        public IStokRepository StokRepository => _stokRepository;
    }
}