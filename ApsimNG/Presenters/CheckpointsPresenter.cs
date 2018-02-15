﻿// -----------------------------------------------------------------------
// <copyright file="CheckpointsPresenter.cs" company="APSIM Initiative">
//     Copyright (c) APSIM Initiative
// </copyright>
// -----------------------------------------------------------------------
namespace UserInterface.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using APSIM.Shared.Utilities;
    using Interfaces;
    using Models.Core;
    using Views;
    using Models.Storage;

    /// <summary>This presenter lets the user add/delete checkpoints</summary>
    public class CheckpointsPresenter : IPresenter
    {
        /// <summary>The model</summary>
        private IModel model;

        /// <summary>The view</summary>
        private IListButtonView view;

        /// <summary>The parent explorer presenter</summary>
        private ExplorerPresenter explorerPresenter;

        /// <summary>Storage model</summary>
        private DataStore storage = null;

        /// <summary>Attach the specified Model and View.</summary>
        /// <param name="model">The axis model</param>
        /// <param name="view">The axis view</param>
        /// <param name="explorerPresenter">The parent explorer presenter</param>
        public void Attach(object model, object view, ExplorerPresenter explorerPresenter)
        {
            this.model = model as IModel;
            this.view = view as IListButtonView;
            this.explorerPresenter = explorerPresenter;

            storage = Apsim.Find(this.model, typeof(DataStore)) as DataStore;

            this.view.List.IsModelList = false;
            this.view.List.Values = storage.Checkpoints().ToArray();
            this.view.AddButton("Add", null, this.OnAddButtonClicked);
            this.view.AddButton("Delete", null, this.OnDeleteButtonClicked);
            PopulateList();
        }

        /// <summary>Detach the model from the view.</summary>
        public void Detach()
        {
        }

        /// <summary>Populate.</summary>
        private void PopulateList()
        {
            view.List.Values = storage.Checkpoints().ToArray();
        }

        /// <summary>The user has clicked the add button.</summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            string checkpointName = Utility.StringEntryForm.ShowDialog(explorerPresenter, "New checkpoint name", 
                                                                       "Enter new checkpoint name:", null);
            if (checkpointName != null)
            {
                bool checkpointExists = storage.Checkpoints().Contains(checkpointName);
                bool addCheckpoint = !checkpointExists ||
                                     explorerPresenter.MainPresenter.AskQuestion("A checkpoint with this name already exists. Do you want to overwrite previous checkpoint?") == QuestionResponseEnum.Yes;
                if (addCheckpoint)
                {
                    explorerPresenter.MainPresenter.ShowWaitCursor(true);
                    storage.AddCheckpoint(checkpointName);
                    PopulateList();
                    explorerPresenter.MainPresenter.ShowWaitCursor(false);
                }
            }
        }

        /// <summary>The user has clicked the delete button.</summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
        }

    }
}
