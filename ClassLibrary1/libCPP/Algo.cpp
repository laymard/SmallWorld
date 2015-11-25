#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 
#include <vector>


using namespace std;



void Algo::fillMap(TileType map[], int size)
{
	// je considere size comme la taille du côté de la carte
	int nbMaxType = pow(size, 2)/4;
	vector<int> max;
	for (int i = 0; i < 4; i++)
	{
		max.push_back(nbMaxType);
	}
	
	//TODO : init map tiles with a better algorithm
	for (int i = 0; i < size; i++)
		map[i] = (TileType)(i % 4);
}