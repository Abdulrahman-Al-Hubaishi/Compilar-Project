#include <iostream>
#include <cstdlib>
using namespace std;
int main() {
  int d = 2 , x , y = 1 ;  
 
 for ( int i = 0 ; i < 8 ; i++) {  for ( int j = 0 ; j < 3 ; j++) {   if( i % d == 0 ) {  cout<<"even:  " <<i <<endl; 
  }  else if ( i % 2 == y ) {  cout<<"odd:  " <<i <<endl; 
  }  else {  cout<<i <<endl; 
  }  
  }  
  }  
 
     system("pause");
    return 0;
}
