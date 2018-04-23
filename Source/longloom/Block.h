// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#define BLOCK_HEIGHT 100.0f
#define BLOCK_WIDTH 100.0f
#define BLOCK_SCALE FVector(BLOCK_WIDTH/1024.0f, 1, BLOCK_HEIGHT/1024.0f)

#include "CoreMinimal.h"
#include "PaperSpriteActor.h"
#include "BlockEnum.h"
#include "Block.generated.h"
/**
*
*/
UCLASS()
class LONGLOOM_API ABlock : public APaperSpriteActor
{
	GENERATED_BODY()
public:
protected:

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Status)
		int32 maxHp;

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = Status)
		int32 hp;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Status)
		int32 resourceValue;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Status)
		BlockType blockType;

public:
	
	ABlock();
	void setBlock(BlockType type, int32 resourceValue);
	void AOnDamaged();
	void AOnDeath();
	void damaged(int atkDamage);
	void destruct();
	UFUNCTION(BlueprintImplementableEvent, Category = "Block")
	void onBlockTypeChanged();
	UFUNCTION(BlueprintCallable, Category = "Block")
	void onHit();
};
