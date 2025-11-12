# No Androids Pass
Using Google Wallet for the equivalent of the [No Homers Pass](https://github.com/sebug/no-homers-pass) project.

[Wallet Flow Documentation](https://developers.google.com/wallet/retail/offers/overview/add-to-google-wallet-flow)

I'd like, if at all possible, to avoid the REST API - If I can sign the stuff myself, then all the better.

## Create your Business Account
To actually issue passes, you'll have to go to your [Google Pay and Wallet Console](https://pay.google.com/business/console/u/0/home) and activate the Google Wallet API.

## Create a service account in the Google Cloud Console
Make a new Google Cloud project for your passes. Then [create a service account](https://developers.google.com/wallet/tickets/events/getting-started/auth/rest)

Once the service account is created, create a key - download the JSON - and invite the user as a developer from the Wallet console.

## Create a resource group in Azure
You'll need this for the static web app that issues the passes.


## Create a static web app
From the resource group and link it to your GitHub repo.

![No Androids Logo](no_androids.png)