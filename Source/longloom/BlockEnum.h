#pragma once
#include "Vector2D.h"

struct BlockTypeInfo {
	int32 maxHp;
	bool collidable;
	FVector2D uv[2];
};

UENUM(BlueprintType)
enum class BlockType : uint8 {
	EMPTY,
	DIRT,
	IRON_ORE,
	DIRT_BG
};

const BlockTypeInfo StaticBlockInfo[] = {
	#define _TEXSIZE 128.0f // Default TextureSize per block
	#define	_TEXV(x) x*_TEXSIZE // Macro Expansion to generate blockinfo
	#define _vec(x,y) FVector2D{_TEXV(x),_TEXV(y)}
	#define uv(x,y) {_vec(x,y+1),_vec(x+1,y)}

	//EMPTY
	BlockTypeInfo{0, false, uv(0,0)},

	//DIRT
	BlockTypeInfo{1, true, uv(0,1) },

	//IRON ORE
	BlockTypeInfo{10, true, uv(0,2)}
};


