#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 
#include <vector>


using namespace std;



void Algo::fillMap(TileType map[], int size)
{
	// je considere size comme la taille du c�t� de la carte
	int nbMaxType = pow(size, 2)/4;
	int randNb = 0;
	vector<int> max;
	for (int i = 0; i < 4; i++)
	{
		max.push_back(nbMaxType);
	}
	srand(time(NULL));
	//TODO : init map tiles with a better algorithm
	for (int i = 0; i < size*size; i++) {
		randNb = rand() % 4;
		while (max[randNb]==0) {
			randNb = rand() % 4;
		}
		map[i] = (TileType)randNb;
		max[randNb] = max[randNb] - 1;
	}
}