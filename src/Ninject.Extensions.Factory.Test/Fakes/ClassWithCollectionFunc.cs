namespace Ninject.Extensions.Factory.Fakes
{
    using System;
    using System.Collections.Generic;

    public class ClassWithCollectionFunc
    {
        private readonly Func<IEnumerable<IWeapon>> enumerableFunc;
        private readonly Func<ICollection<IWeapon>> collectionFunc;
        private readonly Func<IList<IWeapon>> listInterfaceFunc;
        private readonly Func<List<IWeapon>> listFunc;
        private readonly Func<IWeapon[]> arrayFunc;

        public ClassWithCollectionFunc(
            Func<IEnumerable<IWeapon>> enumerableFunc,
            Func<ICollection<IWeapon>> collectionFunc,
            Func<IList<IWeapon>> listInterfaceFunc,
            Func<List<IWeapon>> listFunc,
            Func<IWeapon[]> arrayFunc)
        {
            this.enumerableFunc = enumerableFunc;
            this.collectionFunc = collectionFunc;
            this.listInterfaceFunc = listInterfaceFunc;
            this.listFunc = listFunc;
            this.arrayFunc = arrayFunc;
        }

        public IEnumerable<IWeapon> CreateWeaponsEnumerable()
        {
            return this.enumerableFunc();
        }

        public IEnumerable<IWeapon> CreateWeaponsCollection()
        {
            return this.collectionFunc();
        }
       
        public IList<IWeapon> CreateWeaponsList()
        {
            return this.listInterfaceFunc();
        }
        
        public List<IWeapon> CreateWeaponsListInterface()
        {
            return this.listFunc();
        }
        
        public IWeapon[] CreateWeaponsArray()
        {
            return this.arrayFunc();
        }
    }
}