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
        private readonly IMalzemeTalepleriRepository _malzemeTalepleriRepository;
        private readonly ICariTurRepository _cariTurRepository;
        private readonly ICariRepository _cariRepository;
        private readonly IKDVRepository _kdvRepository;
        private readonly IOdemeVadeRepository _odemeVadeRepository;
        private readonly IParaBirimRepository _paraBirimRepository;

        public TenantUnitOfWork(
            IStokGrupRepository stokGrupRepository,
            IStokOzellikRepository stokOzellikRepository,
            IBirimRepository birimRepository,
            IStokRepository stokRepository,
            IMalzemeTalepRepository malzemeTalepRepository,
            IMalzemeTalepleriRepository malzemeTalepleriRepository,
            ICariTurRepository cariTurRepository,
            ICariRepository cariRepository,
            IKDVRepository kdvRepository,
            IOdemeVadeRepository odemeVadeRepository,
            IParaBirimRepository paraBirimRepository)
        {
            _stokGrupRepository = stokGrupRepository;
            _stokOzellikRepository = stokOzellikRepository;
            _birimRepository = birimRepository;
            _stokRepository = stokRepository;
            _malzemeTalepRepository = malzemeTalepRepository;
            _malzemeTalepleriRepository = malzemeTalepleriRepository;
            _cariTurRepository = cariTurRepository;
            _cariRepository = cariRepository;
            _kdvRepository = kdvRepository;
            _odemeVadeRepository = odemeVadeRepository;
            _paraBirimRepository = paraBirimRepository;
        }

        public IStokGrupRepository StokGrupRepository => _stokGrupRepository;

        public IStokOzellikRepository StokOzellikRepository => _stokOzellikRepository;

        public IBirimRepository BirimRepository => _birimRepository;

        public IStokRepository StokRepository => _stokRepository;

        public IMalzemeTalepRepository MalzemeTalepRepository => _malzemeTalepRepository;
        
        public IMalzemeTalepleriRepository MalzemeTalepleriRepository => _malzemeTalepleriRepository;

        public ICariTurRepository CariTurRepository => _cariTurRepository;

        public ICariRepository CariRepository => _cariRepository;

        public IKDVRepository KDVRepository => _kdvRepository;

        public IOdemeVadeRepository OdemeVadeRepository => _odemeVadeRepository;

        public IParaBirimRepository ParaBirimRepository => _paraBirimRepository;
    }
}