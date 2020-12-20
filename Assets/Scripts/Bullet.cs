using UnityEngine;
public class Bullet: MonoBehaviour
{
    Gun _gun;
    public void SetGun(Gun gun) => _gun = gun; //privately setting/assign gun
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);//when collision occurs we are adding to the pool object
        _gun.AddToPool(this); //F12 to jump to the function

        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
            enemy.TakeDamage(collision.contacts[0].point); //the point of contact is wherre the collision occurs
    }
}