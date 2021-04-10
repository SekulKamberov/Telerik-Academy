namespace ControlFlowCondStatementsLoops
{
    using System;

    public class Chef
    {
        // Task 1
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            PeeledPotato peeledPotato = (PeeledPotato)this.Peel(potato);
            PeeledCarrot peeledCarrot = (PeeledCarrot)this.Peel(carrot);
            CutPotato cutPotato = (CutPotato)this.Cut(peeledPotato);
            CutCarrot cutCarrot = (CutCarrot)this.Cut(peeledCarrot);
            Bowl bowl = this.GetBowl();
            bowl.Add(cutPotato);
            bowl.Add(cutCarrot);
        }

        private Bowl GetBowl()
        {
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private CutVegetable Cut(PeeledVegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private PeeledVegetable Peel(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private Potato GetPotato()
        {
            throw new NotImplementedException();
        }
    }
}