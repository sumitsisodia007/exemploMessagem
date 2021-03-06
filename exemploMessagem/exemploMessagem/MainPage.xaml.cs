﻿using exemploMessagem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace exemploMessagem
{
	public partial class MainPage : MasterDetailPage
	{
        private int quantItens = 0;

		public MainPage()
		{
			InitializeComponent();

            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());

            MessagingCenter.Subscribe<Mensagem>(this, "mensagem", registroItem => {
                quantItens++;
                Item.Text = $"{quantItens} ITENS";
            });
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Mensagem>(this, "mensagem");
        }
    }
}
