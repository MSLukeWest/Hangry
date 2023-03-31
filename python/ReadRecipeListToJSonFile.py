import pandas as pd
import ast
import json

class Recipe:
  def __init__(self, id, name, avg_rating, num_ratings, image_url):
    self.id = int(id)
    self.name = name
    self.avg_rating = avg_rating
    self.num_ratings = int(num_ratings)
    self.image_url = image_url
    self.ingredients = []
    self.cooking_directions = []
    #self.nutrition = []

  def __str__(self):
    return f"{self.id}: {self.name}   Rating: {self.avg_rating} ({self.num_ratings})   Ingredients: {self.ingredients}"

# round average rating into 2 decimal places
def avg_rate(col):
    return f'{col:.2f}'

# split ingredients into list
def parse_ingredients(col):
    return col.split('^')

# split cooking directions into list
def parse_cooking_directions(col):
    return col.split('\\n')

print("Loading recipe data...")
recipe_data = pd.read_csv('raw-data_recipe.csv/raw-data_recipe.csv', nrows=5000)
recipe_data = recipe_data.drop(columns=['reviews'])
print("Recipe data loaded.")

recipe_data.aver_rate = recipe_data.aver_rate.apply(avg_rate)
recipe_data.ingredients = recipe_data.ingredients.apply(parse_ingredients)
recipe_data.cooking_directions = recipe_data.cooking_directions.apply(parse_cooking_directions)

num_recipes = recipe_data.recipe_id.nunique()
print("Recipe data count: ")
print(num_recipes)

# TODO: Don't get IDs, just loop through using indices
list_of_recipes = []
for x in range(num_recipes):
    r1 = Recipe(recipe_data.recipe_id[x], recipe_data.recipe_name[x], recipe_data.aver_rate[x], recipe_data.review_nums[x], recipe_data.image_url[x])
    r1.ingredients = recipe_data.ingredients[x]
    r1.cooking_directions = recipe_data.cooking_directions[x]
    list_of_recipes.append(r1)

print("Writing recipe list to json file...")
json_file = open("recipes.json", "w")
json_file.write("{\n  \"Recipes\": [\n  ")
for r in list_of_recipes:
    json_str = json.dumps(r.__dict__)
    n = json_file.write("  " + json_str + ",\n  ")
json_file.write("]\n}\n")
json_file.close()
print("Finished writing recipe list to json file.")

print("Done")
