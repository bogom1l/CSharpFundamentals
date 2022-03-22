#include <cstdlib>
#include <ctime>
#include <iostream>
#include <thread>
#include <chrono>
using namespace std;



int  random( int min, int max );  //random
bool draw(char arr[20][40], int m, int n);  //draw
bool win(char arr[20][40],int m,int n);  //win_conditions
void player_1(char arr[20][40],int m,int n);  //player_1 turn
void player_2(char arr[20][40],int m,int n);  //player_2 turn



int main ()
{



cout<<"ConnectFour <=> Player VS Computer " <<endl<<endl;


    int m=4,n=4,j;



cout<<endl;
cout<<"\tRows = "<<m<<" , "<<"Columns = "<<n<<endl;



cout<<endl<<endl<<"    Play!  "<<endl<<endl;

//cout_prazna_duska
char arr[20][40];

     for (int i=1; i<m+1; i++)
    {
        for (int j=1; j<n+1; j++)
        {
            arr[i][j] = '_';
            cout<<arr[i][j]<<" ";
        }
           cout<<endl;
    }



//game begins

do
{


    player_1(arr,m+1,n+1);

        if(  draw(arr,m+1,n+1) == true || win(arr,m+1,n+1) == true )
        {
            break;
        }

    cout<<endl<<endl<<"\tT H I N K I N G . . . "<<endl;

        srand((unsigned) time(0));
        int min = 1110;
        int max = 5050;

        int T = (rand() % random(min,max)); // 1 <=> 5 sec




    this_thread::sleep_for(chrono::milliseconds(T));


    player_2(arr,m+1,n+1);

        if(  draw(arr,m+1,n+1) == true || win(arr,m+1,n+1) == true )
        {
            break;
        }


}while(  draw(arr,m+1,n+1) != true  || win(arr,m+1,n+1) == true );



cout<<endl<<endl<<" ~~~ END OF THE GAME ~~~ "<<endl<<endl;


    return 0;
}


//random
int random( int min, int max )
{
   bool first = 1;
   if (first)
   {
      srand( time(0) );
      first = 0;
   }
   return min + rand() % ( (max + 1) - min );
}

//draw
bool draw(char arr[20][40], int m, int n)
{

     int sum = 0;
     for (int i=1; i<m; i++)
     {
        for (int j=1; j<n; j++)
        {
            if ((arr[i][j] == 'X') || (arr[i][j] == 'O'))
                sum++;

                if (sum == (m-1)*(n-1))
                {
                cout<<endl<<" DRAW "<<endl;
                return true;
                }

        }
     }

return false;
}


//win_conditions
bool win(char arr[20][40],int m,int n)
{

    int j;

    for (int i=1; i<m;i++)
    {

        for (int j=1;j<n;j++)
        {

            //vertical_win
            if( arr[i][j] == arr[i-1][j] && arr[i-1][j] == arr[i-2][j] && arr[i-2][j] == arr[i-3][j] )
            {
                if (arr[i][j] == 'X')
                {
                    cout<<endl<<"Player_1 wins! (vertically)"<<endl;
                    return true;
                }
                if (arr[i][j] == 'O')
                {
                    cout<<endl<<"Player_2 wins! (vertically)"<<endl;
                    return true;

                }
            }

            //horizontal_win
            if( arr[i][j] == arr[i][j+1] && arr[i][j+1] == arr[i][j+2] && arr[i][j+2] == arr[i][j+3] )
            {
                if (arr[i][j] == 'X')
                {
                    cout<<endl<<"Player_1 wins! (horizontally)"<<endl;
                    return true;
                }
                if (arr[i][j] == 'O')
                {
                    cout<<endl<<"Player_2 wins! (horizontally)"<<endl;
                    return true;

                }
            }

            //diagonal(nadqsno)_win
            if( arr[i][j] == arr[i-1][j+1] && arr[i-1][j+1] == arr[i-2][j+2] && arr[i-2][j+2] == arr[i-3][j+3] )
            {
                if (arr[i][j] == 'X')
                {
                    cout<<endl<<"Player_1 wins! (diagonally to the right)"<<endl;
                    return true;
                }
                if (arr[i][j] == 'O')
                {
                    cout<<endl<<"Player_2 wins! (diagonally to the right)"<<endl;
                    return true;

                }
            }


            //diagonal(nalqvo)_win
            if( arr[i][j] == arr[i-1][j-1] && arr[i-1][j-1] == arr[i-2][j-2] && arr[i-2][j-2] == arr[i-3][j-3] )
            {
                if (arr[i][j] == 'X')
                {
                    cout<<endl<<"Player_1 wins! (diagonally to the left)"<<endl;
                    return true;
                }
                if (arr[i][j] == 'O')
                {
                    cout<<endl<<"Player_2 wins! (diagonally to the left)"<<endl;
                    return true;

                }
            }


        }


    }


return false;
}





//player_1 turn
void player_1(char arr[20][40],int m,int n)
{

    int j;

NANOVO: //tuk shte izpolzvam goto, kogato nqkoq kolona e pulna, se vryshtam nanovo tuk dokato ne vuveda nomer na nqkoq ne-pulna kolona (163-ti red)
    do{
    cout<<endl<<"Player, choose a column: "<<endl;
    cin>>j;
    }while(j>=n || j<1);


    for (int i = m-1; i >= 1; i--)
    {

      while(j >= 1)
        {

                if (arr[i][j] != 'X' && arr[i][j] != 'O')  //ako e svobodno nai-dolu, padai tam
                {
                      arr[i][j] = 'X';
                      break;
                }
                else    //ako ne e svobodno nai-dolu, proverqva gornoto, posle pak gornoto i t.n. dokato ne nameri svobodno.
                {
                    for(i = m-1; i >= 1; i--)
                    {

                         if (i==1) //proverka dali kolonata e pylna
                          {
                              if (arr[1][j] == 'X' || arr[1][j] == 'O')
                                {
                                cout<<endl<<"This column is full. Inser another one: "<<endl;
                                   goto NANOVO;
                                }
                          }


                      if (arr[i][j] != 'X' && arr[i][j] != 'O')
                      {
                          arr[i][j] = 'X';
                          break;
                      }


                    }
                    break;
                }
        j--;
        }
    break;

    }


    for (int i=1; i<m;i++) //cout the table after player_1 turn
    {
        for (int j=1;j<n;j++)
        {
            cout<<arr[i][j]<<" ";
        }
        cout<<endl;
    }

}








//The AI's Turn
void player_2(char arr[20][40],int m,int n)
{

    int j;

    bool full_column = false;


NANOVO2: //tuk shte izpolzvam goto, kogato nqkoq kolona e pulna, se vryshtam nanovo tuk dokato ne vuveda nomer na nqkoq ne-pulna kolona (238-mi red)
    do{
    cout<<endl;

            srand((unsigned) time(0));
            j = (rand() % n);
            if (j == 0)
            {
                j = j + 1;
            }
            if (full_column == true)
            {
                do{
                    j++;
                }while( j == help4e )
            }




            cout<<endl<<"The AI chose column number = "<<j<<endl;

    }while(j>=n || j<1);


 for (int i = m-1; i >= 1; i--)
    {
         while(j >= 1)
        {

                if (arr[i][j] != 'X' && arr[i][j] != 'O')  //ako e svobodno nai-dolu, padai tam
                {
                      arr[i][j] = 'O';
                      break;
                }
                else    //ako ne e svobodno nai-dolu, proverqva gornoto, posle pak gornoto i t.n. dokato ne nameri svobodno.
                {
                    for(i = m-1; i >= 1; i--)
                    {

                      if (arr[i][j] != 'X' && arr[i][j] != 'O')
                      {
                          arr[i][j] = 'O';
                          break;
                      }
                        else
                        {
                            if (i==1)
                              {
                                cout<<endl<<"This column is full. Inser another one: "<<endl;
                                full_column = true;
                                int help4e = j;
                                goto NANOVO2;
                              }

                        }

                    }
                     break;
                }
                j--;
        }
        break;

    }


    cout<<endl;

    for (int i=1; i<m;i++) //cout the table after player_2 turn
    {
        for (int j=1;j<n;j++)
        {
            cout<<arr[i][j]<<" ";
        }
        cout<<endl;
    }


}





void progress_bar()
{

    double progress = 0.0;
    char left = '<';
    char right = '>';
    bool showProcents = true;
    char full = '-';
    char empty = '_';
    int barWidth = 50;



    int sec = 5;
    int Timer = sec*8;

    if (sec<=6) Timer = 1; //понеже без никви секунди си му отнема 5-6 да го изпринти...
    if (sec>6 && sec <10) Timer = sec*3;
    if (sec>10 && sec<20) Timer = sec*6;
    if (sec>40) Timer = sec*9;






    double sto = 100.0;
    double procenti; //procenti = progress * sto
    float position; //position = barWidth * progress


    while (progress < 1.01)
    {
        procenti = progress * sto;
        cout<<endl<<endl<<"\t\t !!! L O A D I N G !!!"<<endl<<endl;
        cout << left;

        position = barWidth * progress;

        for (int i = 0; i < barWidth; i++)
        {

            if (i < position )
            {
                cout << full;
            }

            else
            {
                cout << empty;
            }


            //centering the procenti number
            if (showProcents == true)
            {
                if (i==barWidth/2)
                {
                    cout<<procenti<<"%";
                }
            }

        }


        cout<<right<<endl;


        this_thread::sleep_for(chrono::milliseconds(Timer));
        cout<<flush;
        system ("CLS");


    progress += 0.01;


    }






    char array[barWidth+2];

     array[0] = left;
     array[barWidth + 1] = right;

    for (int i = 1;i < barWidth + 1; i++)
    {
        array[i] = full;
    }

    int repeat4e = 5;
    while(repeat4e != 0)
    {

                system("CLS");
                this_thread::sleep_for(chrono::milliseconds(170));
                cout<<endl<<endl<<endl<<array<<endl<<endl<<" \t\t ARE YOU READY? "<<endl;
                this_thread::sleep_for(chrono::milliseconds(120));
                repeat4e--;


    }
 system("CLS");





}









