# include<stdio.h>
/*
// Trans. function 
//if tracker is 0 -> trans. is withdrawl
//            is 1 -> trans is deposited
            is 2 -> Trans. is checking bal.
*/

double Trans(int tracker, double money)
{
    //static var bal;
    static double bal = 0;
    switch (tracker)
    {
        case 0:
            bal -= money;
            break;
        case 1:
            bal += money;
            break;
        case 2:
            return bal;
    }
    return 0;
}

//float values
double convert_cash(int CAD, int cents)
{
    //initilize with CAD
    double cash = CAD;

    //the result of float division.
    cash += (cents / 100.0);
    return cash;
}
//process_day that takes
void process_day(int counter)
{

    //and input to No. of days.

    double bal;

    printf("Insert Initial bal (CAD): ");
    scanf("%lf", &bal);

    //set initial bal by calling Trans.()
    Trans(1, bal);
    int i;
    int CAD, cents;
    double spent, RevenueAmount;
    double net;
    //loop to run till given days
    for (i = 1; i <= counter; i++)
    {
        //get money to spend
        printf("\n\nBusiness Day %d\n", i);
        printf("Spending: ");
        scanf("%d %d", &CAD, &cents);
        spent = convert_cash(CAD, cents);

        //get revenu money
        printf("RevenueAmount: ");
        scanf("%d %d", &CAD, &cents);
        RevenueAmount = convert_cash(CAD, cents);

        //cal net money
        net = RevenueAmount - spent;
        printf("\nDays'net: %.2lf\n", net);
        //add RevenueAmount to bal
        Trans(1, RevenueAmount);
        //clear spent money from bal
        Trans(0, spent);
        printf("----------\n\n");
        //print overall bal.
        printf("Ovarall bal: %.2lf\n", Trans(2, 0));
        printf("----------\n");


    }
}
//LASTLY
int main()
{
    //get No. of days as input.
    int num;
    printf("Insert the No. of days: ");
    scanf("%d", &num);
    //call process_day;
    process_day(num);
    return 0;
}
//END