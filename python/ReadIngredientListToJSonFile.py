import pandas as pd
import json

# round average rating into 2 decimal places
def avg_rate(col):
    return f'{col:.2f}'

def parse_ingredients(col):
    return col.split('^')

print("Loading recipe data...")
recipeData = pd.read_csv('raw-data_recipe.csv/raw-data_recipe.csv', nrows=5000)
recipeData = recipeData.drop(columns=['image_url', 'reviews', 'cooking_directions', 'nutritions'])
print("Recipe data loaded.")

recipeData.aver_rate = recipeData.aver_rate.apply(avg_rate)
recipeData.ingredients = recipeData.ingredients.apply(parse_ingredients)

list_of_ingredients = []
for row in recipeData.ingredients:
    for ingredient in row:
        list_of_ingredients.append(ingredient)

ingredients_set = set(list_of_ingredients)
json_str = json.dumps(list(ingredients_set))

print("Writing ingredient list to json file...")
json_file = open("ingredients.json", "w")
json_file.write("{\n  \"IngredientNames\": [")
json_file.write("    " + json_str + "\n")
json_file.write("]\n}\n")
json_file.close()
print("Finished writing ingredient list to json file.")

print("Done")
