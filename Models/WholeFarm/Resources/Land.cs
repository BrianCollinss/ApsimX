﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;  //enumerator
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Models.Core;

namespace Models.WholeFarm.Resources
{
    ///<summary>
    /// Parent model of Land Types.
    ///</summary> 
    [Serializable]
    [ViewName("UserInterface.Views.GridView")]
    [PresenterName("UserInterface.Presenters.PropertyPresenter")]
    [ValidParent(ParentType = typeof(ResourcesHolder))]
    public class Land: ResourceBaseWithTransactions
	{
        /// <summary>
        /// Current state of this resource.
        /// </summary>
        [XmlIgnore]
        public List<LandType> Items;

		/// <summary>
		/// Unit of area to be used in this simulation
		/// </summary>
		[System.ComponentModel.DefaultValueAttribute(UnitsOfAreaType.Hectares)]
		[Description("Unit of area to be used in this simulation")]
		public UnitsOfAreaType UnitsOfArea { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		public Land()
		{
			this.SetDefaults();
		}

		/// <summary>An event handler to allow us to initialise ourselves.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		[EventSubscribe("Commencing")]
        private void OnSimulationCommencing(object sender, EventArgs e)
        {
			foreach (var child in Children)
			{
				if (child is IResourceWithTransactionType)
				{
					(child as IResourceWithTransactionType).TransactionOccurred += Resource_TransactionOccurred; ;
				}
			}
        }

		#region Transactions

		// Must be included away from base class so that APSIM Event.Subscriber can find them 

		/// <summary>
		/// Override base event
		/// </summary>
		protected new void OnTransactionOccurred(EventArgs e)
		{
			EventHandler invoker = TransactionOccurred;
			if (invoker != null) invoker(this, e);
		}

		/// <summary>
		/// Override base event
		/// </summary>
		public new event EventHandler TransactionOccurred;

		private void Resource_TransactionOccurred(object sender, EventArgs e)
		{
			LastTransaction = (e as TransactionEventArgs).Transaction;
			OnTransactionOccurred(e);
		}

		#endregion
	}


}
