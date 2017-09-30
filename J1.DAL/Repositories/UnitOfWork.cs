using System;

namespace J1.DAL.Repositories
{
	public class UnitOfWork: IDisposable
	{
		private readonly J1Context context = new J1Context();

		private AuthRepository _authRepository;
		private BrandRepository _brandRepository;
		private BuyerRepository _buyerRepository;
		private ClassificationRepository _classificationRepository;
		private ProductAlternateCodeRepository _productAlternateCodeRepository;
		private ProductAlternateSkuRepository _productAlternateSkuRepository;
		private ProductRepository _productRepository;
		private ProductTagRepository _productTagRepository;
		private SaleItemRepository _saleItemRepository;
		private SaleRepository _saleRepository;
		private SaleShipmentRepository _saleShipmentRepository;
		private SupplierRepository _supplierRepository;
		private TagRepository _tagRepository;

		private KitAlternateCodeRepository _kitAlternateCodeRepository;
		private KitAlternateSkuRepository _kitAlternateSkuRepository;
		private KitRepository _kitRepository;
		private KitTagRepository _kitTagRepository;
		private KitItemRepository _kitItemRepository;

		private TenantRepository _tenantRepository;
		private UserRepository _userRepository;
		
		#region repositories
		public AuthRepository AuthRepository
		{
			get
			{
				if( this._authRepository == null )
					this._authRepository = new AuthRepository();
				return this._authRepository;
			}
		}

		public IBrandRepository BrandRepository
		{
			get
			{
				this._brandRepository = this._brandRepository ?? new BrandRepository( this.context );
				return this._brandRepository;
			}
		}

		public IBuyerRepository BuyerRepository
		{
			get
			{
				this._buyerRepository = this._buyerRepository ?? new BuyerRepository( this.context );
				return this._buyerRepository;
			}
		}

		public IClassificationRepository ClassificationRepository
		{
			get
			{
				this._classificationRepository = this._classificationRepository ?? new ClassificationRepository( this.context );
				return this._classificationRepository;
			}
		}

		public IProductAlternateCodeRepository ProductAlternateCodeRepository
		{
			get
			{
				this._productAlternateCodeRepository = this._productAlternateCodeRepository ?? new ProductAlternateCodeRepository( this.context );
				return this._productAlternateCodeRepository;
			}
		}

		public IProductAlternateSkuRepository ProductAlternateSkuRepository
		{
			get
			{
				this._productAlternateSkuRepository = this._productAlternateSkuRepository ?? new ProductAlternateSkuRepository( this.context );
				return this._productAlternateSkuRepository;
			}
		}

		public IProductRepository ProductRepository
		{
			get
			{
				this._productRepository = this._productRepository ?? new ProductRepository( this.context );
				return this._productRepository;
			}
		}

		public IProductTagRepository ProductTagRepository
		{
			get
			{
				this._productTagRepository = this._productTagRepository ?? new ProductTagRepository( this.context );
				return this._productTagRepository;
			}
		}

		public ISaleItemRepository SaleItemRepository
		{
			get
			{
				this._saleItemRepository = this._saleItemRepository ?? new SaleItemRepository( this.context );
				return this._saleItemRepository;
			}
		}

		public ISaleRepository SaleRepository
		{
			get
			{
				this._saleRepository = this._saleRepository ?? new SaleRepository( this.context );
				return this._saleRepository;
			}
		}

		public ISaleShipmentRepository SaleShipmentRepository
		{
			get
			{
				this._saleShipmentRepository = this._saleShipmentRepository ?? new SaleShipmentRepository( this.context );
				return this._saleShipmentRepository;
			}
		}

		public ISupplierRepository SupplierRepository
		{
			get
			{
				this._supplierRepository = this._supplierRepository ?? new SupplierRepository( this.context );
				return this._supplierRepository;
			}
		}

		public ITagRepository TagRepository
		{
			get
			{
				this._tagRepository = this._tagRepository ?? new TagRepository( this.context );
				return this._tagRepository;
			}
		}

		public IKitAlternateCodeRepository KitAlternateCodeRepository
		{
			get
			{
				this._kitAlternateCodeRepository = this._kitAlternateCodeRepository ?? new KitAlternateCodeRepository( this.context );
				return this._kitAlternateCodeRepository;
			}
		}

		public IKitAlternateSkuRepository KitAlternateSkuRepository
		{
			get
			{
				this._kitAlternateSkuRepository = this._kitAlternateSkuRepository ?? new KitAlternateSkuRepository( this.context );
				return this._kitAlternateSkuRepository;
			}
		}

		public IKitRepository KitRepository
		{
			get
			{
				this._kitRepository = this._kitRepository ?? new KitRepository( this.context );
				return this._kitRepository;
			}
		}

		public IKitTagRepository KitTagRepository
		{
			get
			{
				this._kitTagRepository = this._kitTagRepository ?? new KitTagRepository( this.context );
				return this._kitTagRepository;
			}
		}

		public IKitItemRepository KitItemRepository
		{
			get
			{
				this._kitItemRepository = this._kitItemRepository ?? new KitItemRepository( this.context );
				return this._kitItemRepository;
			}
		}

		public ITenantRepository TenantRepository
		{
			get
			{
				this._tenantRepository = this._tenantRepository ?? new TenantRepository( this.context );
				return this._tenantRepository;
			}
		}

		public IUserRepository UserRepository
		{
			get
			{
				this._userRepository = this._userRepository ?? new UserRepository( this.context );
				return this._userRepository;
			}
		}
		
		#endregion repositories

		public void Save()
		{
			this.context.SaveChanges();
		}

		private bool disposed;

		protected virtual void Dispose( bool disposing )
		{
			if( !this.disposed )
			{
				if( disposing )
				{
					this.context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			this.Dispose( true );
			GC.SuppressFinalize( this );
		}
	}
}
