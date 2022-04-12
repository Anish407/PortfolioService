# Stock Portfolio API

## Description
The lazy coder has been trying to build an API to fetch portfolios, get the total value of each portfolio, and delete them. Some parts of the system work but it seems a bit buggy. 

One suspicion is that the currency conversions are at fault but since the lazy developer has moved on to become a gardener no one knows how to identify the problem and potentially fix it; that's where you come in.

## What To Do
Should take on average about 2 hours to complete. Since you may not have time to do everything, please briefly explain what you chose to do and why.

The code smells. It is filled with bad decisions, incomplete logic and half baked projects. Your job is, to the best of your ability, refactor the code so that it meets the following criteria:
- An endpoint exists that returns the specified portfolio.
- An endpoint exists that returns the total value of all stocks in the portfolio in the specified currency.
- An endpoint exists to soft-delete portfolios (whatever that means, we don't know but we don't want to permanently lose the data).
- Has some unit tests (note: should not be exhaustive).
- Exchange rates should be fetched from CurrencyLayer and we will give you an API key privately. Exchange rates do not need to be fetched for every call, and only need to be refreshed every 24 hours. Documentation is available at https://currencylayer.com/documentation. The account linked to the API key only has permission to get USD exchange rates, so you will need to convert from the base exchange rate to USD and then from USD to the target exchange rate.

_NOTE: The project StockService is impeccable and is off limits, you cannot change it whatsoever._

In addition to the above, we also want you to refactor some of the codebase using best practices. We have no idea what all this means, some consultant just told us. Feel free to use any 3rd party libraries to help you with the task, given they are OSS.

## Database
The project uses MongoDB as persistence by default. You are of course free to use another DB but if you do, you will have to explain why, as with any decision made in the code base during a technical interview.

### Database Setup
If you have not used MongoDB before, you can follow these steps for installation and for seeding the database. We optionally recommend using Robo 3T for viewing the data.

1. Install MongoDB Community Server: https://www.mongodb.com/try/download/community
1. Install MongoDB Database Tools: https://docs.mongodb.com/database-tools/installation/installation-windows/ (install and add to PATH)
1. Open a command prompt and browse to /scripts, then run the command `mongoimport --collection=Portfolios --db=portfolioServiceDb portfolios.json` (you should receive confirmation that 2 documents have imported successfully)

## When Finished
**Please send the code test to us by creating a pull request to the main branch.**
