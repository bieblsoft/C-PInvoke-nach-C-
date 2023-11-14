// TraditionalDll3.cpp
// compile with: /LD /EHsc
#include <iostream>
#include <stdio.h>
#include <math.h>

#define STRUCTLAYOUT_EXPORTS
#ifdef STRUCTLAYOUT_EXPORTS
   #define STRUCTLAYOUT_API __declspec(dllexport)
#else
   #define STRUCTLAYOUT_API __declspec(dllimport)
#endif

#pragma pack(push, 8)

struct Location 
{
   int x;
   int y;
};

#pragma pack(pop)

extern "C"
{
   STRUCTLAYOUT_API double GetDistance(Location, Location);
   STRUCTLAYOUT_API void InitLocation(Location*);
}

double GetDistance(Location loc1, Location loc2) {
   printf_s("[sent from managed] loc1(%d,%d)", loc1.x, loc1.y);
   printf_s(" loc2(%d,%d)\n", loc2.x, loc2.y);

   double h = loc1.x - loc2.x;
   double v = loc1.y - loc2.y;
   double dist = sqrt( pow(h,2) + pow(v,2) );

   return dist;
}

void InitLocation(Location* lp) {
   printf_s("[using pointer to managed struct] Initializing location...\n");
   lp->x = 50;
   lp->y = 80;
}
