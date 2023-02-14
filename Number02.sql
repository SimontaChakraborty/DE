select training_details.user_ID, users.user_Name, training_details.training_id, training_details.training_date, count(training_details.training_id)
from training_details join users on training_details.user_ID = users.user_ID
group by training_details.user_ID, users.user_Name, training_details.training_id, training_details.training_date
having count(training_details.training_id) > 1
order by training_details.training_date desc;

