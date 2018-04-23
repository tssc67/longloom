// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

#include "longloomGameMode.h"
#include "longloomCharacter.h"
#include "Engine/World.h"
#include "TestActor.h"
#include "FileHelper.h"
#include "Block.h"
#include "ConstructorHelpers.h"
#include "Engine/Blueprint.h"

#include <vector>

using namespace std;

struct MapData {
	BlockType** grid;
	int width;
	int height;
};

AlongloomGameMode::AlongloomGameMode()
{
	// Set default pawn class to our character
	static ConstructorHelpers::FObjectFinder<UBlueprint> BPObj(TEXT("Blueprint'/Game/2DSideScroller/BlockBP.BlockBP'"));
	BlueprintVar = (UClass*)BPObj.Object->GeneratedClass;

	DefaultPawnClass = AlongloomCharacter::StaticClass();	
}



MapData LoadMap(FString fileName) {
	MapData out;
	out.width = 0;
	out.height = 0;

	FString data;
	FFileHelper::LoadFileToString(data, *(FPaths::GameDir() + fileName));
	TArray< FString > rows;
	
	UE_LOG(LogTemp, Warning, TEXT("Map data: %s \n%s"), *(FPaths::GameDir() + fileName), *data);

	data.ParseIntoArrayLines(rows, true);
	out.height = rows.Num();
	out.grid = new BlockType*[out.height];
	int i = 0;
	for (const auto& row : rows) {
		TArray< FString > blockStrings;
		row.ParseIntoArray(blockStrings, TEXT(","),true);
		out.width = blockStrings.Num();
		out.grid[i] = new BlockType[out.width];
		int j = 0;
		for (const auto& blockString : blockStrings) {
			TArray< FString > blockData;
			blockString.ParseIntoArray(blockData, TEXT("|"),true);
			UE_LOG(LogTemp, Warning, TEXT("%s"),*blockData[0]);
			out.grid[i][j] = (BlockType)FCString::Atoi(*blockData[0]);
			//out.grid[i][j] = StaticBlockInfo[FCString::Atoi(*blockData[0])];
			j++;
		}
		i++;
	};
	//UE_LOG(LogTemp, Warning, TEXT("0[hp]: %d %d"), out.grid[0][0].maxHp, out.grid[0][1].maxHp);
	UE_LOG(LogTemp, Warning, TEXT("Map size %d %d"),out.width,out.height);
	return out;
}

void AlongloomGameMode::PreInitializeComponents() {
	//static ConstructorHelpers::FObjectFinder<UClass> BPObj(TEXT("Blueprint'/Game/2DSideScroller/BlockBP'"));
	MapData m = LoadMap("defaultMap.csv");
	UE_LOG(LogTemp, Warning, TEXT("Generating Map"));
	UWorld* world = GetWorld();
	grid = new ABlock**[m.height];
	for (int32 i = m.height - 1; i >= 0; i--) {
		grid[i] = new ABlock*[m.width];
		for (int32 j = 0; j < m.width; j++) {
			FVector Location(j * BLOCK_WIDTH, 0.0f, i * BLOCK_HEIGHT);
			FRotator Rotation(0.0f, 0.0f, 0.0f);
			FActorSpawnParameters SpawnInfo;
			grid[i][j] = world->SpawnActor<ABlock>(BlueprintVar, Location, Rotation, SpawnInfo);
			grid[i][j]->setBlock(m.grid[i][j], 1);
		}
	}
	AGameModeBase::PreInitializeComponents();
}

